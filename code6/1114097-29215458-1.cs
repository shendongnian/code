    public float nthsAverage(int n, int[] numbers)
    {
         // quick check to avoid a divide by 0 error
         if (numbers.Length  == 0)
            return 0;
         int sum = 0;
         int count = 0;
         for (int i = 0; i < numbers.Length; i++)
         {
             // might want i+1 here instead to compensate for array being 0 indexed, ie 9th number is at the 8th index
             if (i % n == 0)
             {
                  sum = sum + numbers[i];
                  count++; 
             }
         }
         return (float)sum / count;
    }
