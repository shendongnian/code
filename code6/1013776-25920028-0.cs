       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Threading.Tasks;
    
    namespace FormLetter
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                string random="";
                string random2 ="";
                string random3 ="";
             do{
                //array of strings
                string[] phrases = { "Buy it today", "You won't regret your purchase", "Satisfaction is                   guaranteed", "Purchase of a lifetime", "Such a great deal", "Limited time only" };
                Random r = new Random();
                random = phrases[r.Next(0, 5)];
                random2 = phrases[r.Next(0, 5)];
                random3 = phrases[r.Next(0, 5)];
               }while(compareStrings(random,random2, random3))
    
                RanStrings(random, random2, random3);
            }
    
            private static void RanStrings(string random, string random2, string random3)
            {
                Console.WriteLine(random);
                Console.WriteLine(random2);
                Console.WriteLine(random3);
            }
            private static bool compareStrings(string random, string random2, string random3)
            {
                //put here your comparison code
                if (there is equality between 2 strings passed in argument)
                return true;
                else  return false;
            }
        }
    }
