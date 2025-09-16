//Fullstackutveckling .NET25 Oscar Norén
using System;
using System.Globalization;
using System.Security.Cryptography;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //While-statement is active whilst the program is on
            while (true)
            {
                //Choose your difficulty by writing 1, 2 or 3. The \n is just for a new line so it looks better
                Console.WriteLine("Välj svårighetsgrad: \n" + "1. Enkel\n" + "2. Mellan\n" + "3. Svår\n");
                //Because string diff is in the loop the program does not shut off if you get to default
                string diff = Console.ReadLine();
                //Switch cases are a smoother way than to write if/else/else if a lot
                switch (diff)
                {
                    case "1":
                        NumbersGameEasy();
                        break;

                    case "2":
                        NumbersGameMedium();
                        break;

                    case "3":
                        NumbersGameHard();
                        break;

                    default:
                        Console.WriteLine("Valet finns inte, välj mellan 1-3");

                        break;

                }
            }
            
        }

        static void NumbersGameEasy()
        {
            //Random is a randomized variable that with the help of int number can only appear between 1 and 10
            Random random = new Random();
            int number = random.Next(1, 10);
            //Life is an int variable with a hardcoded value of 5
            //The reason life is 5 instead of 6 is so that you actually get 6 tries instead of 7, the code changed a tiny amount due to checkguess
            int life = 5;
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-10. Kan du gissa vilket? Du får sex försök.");
            //The while loop is active until life turns to 0
            while (life >= 0)
            {
                //TryCatch makes it so that you can only enter numbers because choice is an int
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    //A function to see if your guess was right or wrong
                    CheckGuess(number, life, choice);
                    life--;
                }
                //If you write something thats not an int you come here as a warning instead that the system shuts down
                catch (FormatException e)
                {
                    Console.WriteLine("Skriv snälla bara siffror");
                }

            }
        }

        static void NumbersGameMedium()
        {
            //Random is a randomized variable that with the help of int number can only appear between 1 and 25
            Random random = new Random();
            int number = random.Next(1, 25);
            //Life is an int variable with a hardcoded value of 5
            int life = 5;
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-25. Kan du gissa vilket? Du får fem försök.");
            //The while loop is active until life turns to 0
            while (life >= 0)
            {
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    CheckGuess(number, life, choice);
                    life--;
                }

                catch (FormatException e)
                {
                    Console.WriteLine("Skriv snälla bara siffror");
                }

            }
        }


        static void NumbersGameHard()
        {
            //Random is a randomized variable that with the help of int number can only appear between 1 and 50
            Random random = new Random();
            int number = random.Next(1, 50);
            //Life is an int variable with a hardcoded value of 2 
            int life = 2;
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-50. Kan du gissa vilket? Du får tre försök.");
            //The while loop is active until life turns to 0
            while (life >= 0)
            {
                try 
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    CheckGuess(number, life, choice);
                    life--;
                }

                catch (FormatException e)
                {
                    Console.WriteLine("Skriv snälla bara siffror");
                }

                

            }
        }


        static void CheckGuess(int number, int life, int choice)
        {
            if (choice == number)
            {
                //Retry is a function to retry the game if you want to
                Console.WriteLine("Wohoo! Du klarade det!");
                Retry();
            }
            else if (choice > number)
            {
                Console.WriteLine("Tyvärr, du gissade för högt!");
               
            }
            else if (number > choice)
            {
                Console.WriteLine("Tyvärr, du gissade för lågt!");
                
            }
            //Game over
            if (life == 0)
            {
                Console.WriteLine("Tyvärr, du lyckades inte gissa talet!");
                Retry();
            }
        }

        static void Retry()
        {
            
            //Retry function where you can either stop the game or restart   
            Console.WriteLine("Do you want to retry? Yes or no?");
            string again = Console.ReadLine();
            switch (again)
            {
                case "yes":
                    //Clears the console of text so that it doesnt get cluttered
                    Console.Clear();
                    Console.WriteLine("Restarting game");
                    //this int life = 0, is just a way to reset life if you get it right.
                    int life = 0;
                    return;

                case "no":
                    Console.WriteLine("Have a good day");
                    Environment.Exit(3000);
                    break;

                default:
                    Console.WriteLine("Please write yes or no!");
                    Console.ReadLine();
                    break;
            }

        }
    }
}