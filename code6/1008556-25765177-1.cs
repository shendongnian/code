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
               num[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < num.Length; i++ )
            {
                sum += num[i] * num[i]; // this will now square the values, then add them to sum
            }
    
            Console.WriteLine(sum);
    
            Console.ReadLine();
    
        }
    
    }
    }
