    public static int MaximumNumber(params int[] numbers)
        {
            int max = 0;
            for(int i=0; i<numbers.Length-1; i++)
            {
                if( numbers[i]>numbers[i+1] & numbers[i]>max )
                {
                    max = numbers[i];
                }
                else if(numbers[i+1]>max)
                {
                    max = numbers[i + 1];
                }
            }
            return max;
        }
