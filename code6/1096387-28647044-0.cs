    using System;
    
    namespace CurrencyNotes
    {
        class Program
        {
            static void Main(string[] args)
            {
                int amount;
                int choice;
    
                Console.Write("Enter the amount: ");
                amount = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("Enter the value of note from which you want to start: ");
                choice = Convert.ToInt32(Console.ReadLine());
    
                CountNotes(amount, choice);
            }
    
            static void CountNotes(int amount, int choice)
            {
    	        int notes = 0;
    	        int[] choices = { 100, 50, 20, 10, 5, 2, 1 };
    
    	        // Find starting choice
    	        int i = 0;
    	        while (choice < choices[i])
    		        ++i;
    
    	        // Output number of notes for each suitable choice
    	        while (amount > 0)
    	        {
    		        notes = amount / choices[i];
    		        if (notes > 0)
    			        Console.WriteLine("no. of {0} rupees notes = {1}", choices[i], notes);
    		        amount %= choices[i];
    		        ++i;
    	        }
            }
        }
    }
