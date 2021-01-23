		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Text.RegularExpressions;
		
		namespace ConsoleApplicationTEST
		{
		    class Program
		    {
		        static void Main(string[] args)
		        {
		            int[,] matrix = new int[5, 8] { 
		               {  1,  2,  3,  4,  5,  6,  7,  8 }, 
		               {  9, 10, 11, 12, 13, 14, 15, 16 },
		               { 17, 18, 19, 20, 21, 22, 23, 24 },
		               { 25, 26, 27, 28, 29, 30, 31, 32 },
		               { 33, 34, 35, 36, 37, 38, 39, 40 },
		            };
		
		            int[,] newArray = new int[8, 5];
		            for (int j = 0; j < 8; j++)
		                for (int r = 0; r < 5; r++)
		                    newArray[j, r] = matrix[r, j];
		
		            for (int r = 0; r < 8; r++)
		            {
		                for (int c = 0; c < 5; c++)
		                {
		                    Console.Write(newArray[r,c] + " ");
		                }
		                Console.WriteLine();
		            }
		
		            Console.ReadLine();
		
		        }
		    }
		}
		
