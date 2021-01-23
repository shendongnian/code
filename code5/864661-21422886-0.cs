    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace take3highestsum
    {
    class Program
    {
        static void Main(string[] args)
        {
            //question sequence
            List<int> intlist = new List<int> { 1, 1, 2, 3, 5, 2, 1, 3, 7, 1 };
             
            //display in console stuff not part of answer
            foreach (int a in intlist)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            
            //begin answer
            
            //check for legit list since we need at least 3 elements
            if (intlist.Count < 3) { throw new Exception("List must have more than 3 elements"); }
            //stuff we will need
            int lastindx = intlist.Count - 1, baseindex = -1;            
            //begin LINQ
            int[] result = intlist.Select(a =>
            {
                baseindex++;//increment
                //return each sequence of three numbers
                return new int[]{ 
                    intlist[baseindex],//always base index
                    baseindex + 1 > lastindx ? 0 : intlist[baseindex + 1], //base index + 1 or 0 if out of bounds 
                    baseindex + 2 > lastindx ? 0 : intlist[baseindex + 2] };//base index + 2 or 0 if out of bounds 
            }).OrderByDescending(b => b.Sum()).First();
            //end LINQ
            //end answer
             
             //stuff to display proof
            foreach (int a in result)
            {    
                Console.Write(a);
            }
         
            Console.ReadLine();
        }
     }
    }
