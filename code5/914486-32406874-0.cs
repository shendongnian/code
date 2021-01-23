    using System;
    
    class Solution {
        public int solution(int[] A) {
            
            // first compute the sum of the array, put in second half sum.
            int firstsum = 0;
            int secondsum = 0;
        
            foreach (int num in A)
            {
                secondsum += num;
            }
        
            // kepp an index 
            int index = 0;
        
            while ( index <= A.Length -1 )
            {
                secondsum -= A[index];
            
                if (secondsum == firstsum)
                {
                    return index;
                }
            
                firstsum += A[index];
                ++ index;
            }
        
            return -1;
        }
    }
