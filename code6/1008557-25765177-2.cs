    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Program
    {
    class Third
    {
    
        public static void Main()
        {
    
            Console.WriteLine("Enter how many numbers");
    
            int howMuch = int.Parse(Console.ReadLine());
    
            int[] num = new int[howMuch];
    
            int sum = 0;
            for(int i=0;i<num.Length;i++) //allows you to fill the array
            {
               Console.WriteLine("Please enter an integer");
                sum *= int.Parse(Console.ReadLine()); // this will now multiply the value to sum, as your comment suggests
            }
    
            Console.WriteLine(sum);
    
            Console.ReadLine();
    
        }
    
    }
    }
