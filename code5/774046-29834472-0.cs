     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     using System.Collections;
      public int solution(int X, int[] A)
    {
        // write your code in C# 5.0 with .NET 4.5 (Mono)
        int N = A.Length;
        int step = 0;
        List<int> k = new List<int>();
        for (int i = 0; i < X; i++)
        {
            k.Add(0);
        }
        //Inserts an element into the ArrayList at the specified index.
        for (int i = 0; i < N; i++)
        {
            int diff = A[i] - 1;
            k[diff] = A[i];
            if (i >= X-1 && (k.Contains(0) == false))
            {
               return i;
              
            }
    
        }
        return -1;
    }
