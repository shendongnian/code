    public void DuplicateElementsInArray(int[] numbers)
        {
            int count = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                
                for (int j = i; j < numbers.Length - 1; j++)
                {
                    if (numbers[i] == numbers[j+1])
                    {                       
                        count++;
                        break;
                    }                       
                }               
            }
            Console.WriteLine("Total number of duplicate elements found in the array is: {0}", count);
        }
