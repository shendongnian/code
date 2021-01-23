    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace GuessingGameProgram
    {
    class Program
    {
        int randNum;
        static void Main(string[] args)
        {
            // Create a string array that consists of ten lines. 
            string[] personalNumbers; // declare personalNumbers as a 10-element array 
            personalNumbers = new string[10];  //= { "First number", "Second number", "Third line",   etc}
            
            Random outsideLoopRandom = new Random();
            int randomNumber = outsideLoopRandom.Next(1, 50);
            for (int i = 0; i < 9; i++)   // populate the array  with 10 random values
            {
                randomNumber = outsideLoopRandom.Next(1, 50);
                string RandomNumberText = Convert.ToString(randomNumber);
                personalNumbers[i] = RandomNumberText;   
            }
            // WriteAllLines creates a file, writes a collection of strings to the file, 
            // and then closes the file.
            //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
            
            foreach (string i in personalNumbers) // this is just a test to see what the output is
            {
                Console.Write("{0} ", i);
            }
            Console.ReadLine();
        }
    }
}  
         
            
            
            
          
            //randNum = Random.Equals(1, 50);
            //StreamReader myReader = new StreamReader("personalNumbers.txt");
            //string line = "";
            //while (line != null)
            //{
            //    line = myReader.ReadLine();
            //    if (line != null)
            //        Console.WriteLine(line);
            //}
            //myReader.Close();
            //Console.ReadLine();
            //personalNumbers = RandomNumbers.next(1, 10);
            //int returnValue = personalNumbers.Next(1, 50);
            //int Guess = 0;
            //Console.WriteLine("Please guess a number between 1 and 50");
            //Console.ReadLine();
            ////while (Guess = Convert.ToInt32(Console.Read());
            //if (Guess < returnValue)
            //{
            //    Console.WriteLine("Wrong! the number that I am thinking of is higher than " + Guess + ". Try again!");
            //    Console.ReadLine();
            //}
            //if (Guess > returnValue)
            //{
            //    Console.WriteLine("Wrong! The number that I am thinking of is lower than " + Guess + ". Try again!");
            //    Console.ReadLine();
            //}
            //        else if (Guess = returnValue)
            //        Console.WriteLine("Correct! The number that I was thinking of was " + Guess + ". Congratulations!");
        //    //{
        //Console.WriteLine("Let's play a guessing game!")
        //Console.WriteLine("")
        //Console.WriteLine("guess a number between 1 and 10")
        //Console.WriteLine("")
       
        //randNum = randomGenerator.Next(1, 10)
        //While userGuess <> randNum
        //    {
        //    userGuess = Console.ReadLine()
        //    }
        //    If userGuess > randNum Then
        //        Console.WriteLine("too high, guess again!")
        //    {
        //   If userGuess < randNum Then
        //        Console.WriteLine("too low, guess again!")
        //    }
        //   Else
        //End While
        //Console.WriteLine("Correct! the secret number is " & randNum)
        //Console.ReadLine()
       
