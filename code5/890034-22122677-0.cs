    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            
            int[] array1 = { 1, 2 };
    
            int[][] varray = new int[4][];
            
            varray[0] = new int[] { 1, 2 };
            varray[1] = new int[] { 3, 4 };
            varray[2] = new int[] { 3, 4, 1 };
            varray[3] = new int[] { 3, 4, 9, 10 };
            
            Console.WriteLine("varray.length = " + varray.Length);
            Console.WriteLine("varray[0].length = " + varray[0].Length);
            
            int k = 0;
            for (int i = 0; i < varray.Length; i++) { 
                Console.WriteLine(" i = " + i);
                for(int j = 0; j < varray[i].Length; j++) {
                    if (j < array1.Length && varray[i][j] == array1[k++]) {                                                                      
                        Console.WriteLine(" j = " + j);
                        Console.WriteLine("varray contains array1"); 
                    }
                }
                k = 0;
            } 
        }
    }
