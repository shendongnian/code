    public float nthsAverage(int n, int[] numbers)
    {
         int sum = 0;
         int count = 0;
         for (int i = 0; i < numbers.Length; i++)
         {
             if (i % n == 0)
             {
                  sum = sum + numbers[i];
                  count++; 
             }
         }
         return (float)sum / count;
    }
