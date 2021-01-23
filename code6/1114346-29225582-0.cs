    using System.Collections.Generic;
    static void Main(string[] args)
        {
    
            //checks how many numbers will be entered
            int manyNumbers;
            Console.WriteLine("How many numbers will you enter?");
            manyNumbers = Convert.ToInt32(Console.ReadLine());
    
    		Dictionary<int, int> array = new Dictionary<int, int>();
    
            //starts asking for numbers
            for (int i = 0; i < manyNumbers; )
            {
                Console.Write("\nEnter number: ");
                string entered = Console.ReadLine();
                int val;
    
                //checks to see if valid number
                if (!Int32.TryParse(entered, out val)) 
                {
                    Console.Write("Invalid number '{0}'", entered);
                }
                //checks to see if already entered
                else 
                if (i > 0 && array.ContainsKey(val)) 
                {
                    Console.Write("{0} has already been entered", val);
                    //array[i++] = val;
                }
                else
                {
    			    //* add the new integer to list
    				array.Add(val, 0);
    
                   //prints the complete list
                    List<int> keys = new List<int>(array.Keys);
                    Console.WriteLine();
    				for(int j=0; j<keys.Count; j++) Console.WriteLine(keys[j]);
                }						   
    
    
    
    
            }
    
        }
