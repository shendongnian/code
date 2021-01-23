    using System;
    using System.Linq;
    
    namespace Test
    {
    	class Program
    	{
    		static void Main()
    		{
    			int chosenRandom;
    			Console.WriteLine("Choose a number between 0-10");
    			chosenRandom = int.Parse(Console.ReadLine());
    
    			Random rand = new Random();
    			double[] randomNumbers = new double[chosenRandom];
    			for(int i = 0; i < chosenRandom; i++)
    			{
    				Console.WriteLine("Random numbers: " + (randomNumbers[i] = rand.Next(0, 10)));
    			}
    
    			double average = randomNumbers.Average(t => t);
    
    			var numbersAboveAverage = randomNumbers.Where(t => t > average);
    			Console.WriteLine("Average of all random numbers - {0}", average);
    
    			foreach(var number in numbersAboveAverage)
    				Console.WriteLine(number);
    
    		}
    	}
    }
