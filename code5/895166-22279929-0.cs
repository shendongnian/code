    using System.IO;
    
    using System;
    
    using System.Linq;
    
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            List<int> A= new List<int>(){33,50,30,90,1,4,5,6,66,}; 
            List<int> B=new List<int>(){50,4,33};
                   
            Console.WriteLine("using linq:");
    
            foreach(int i in A.Except(B).ToList())
            Console.WriteLine(i);
            
            Console.WriteLine("without using linq:");
    
            foreach(int i in Except(A,B))
            Console.WriteLine(i);
        }
        
        private static List<int> Except(List<int> A,List<int>B)
        {
            List<int> c = new List<int>();
            foreach(int i in A)
            {
                if(B.Contains(i))
                   continue;
                else
                   c.Add(i);
            }
            return c;
        }
        
    }
