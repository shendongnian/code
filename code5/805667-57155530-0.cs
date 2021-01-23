            int[] nums = new int[] { 1, 2, 3, 4, 5};
            Console.WriteLine(AnyDuplicate(nums));
        }
        /// <summary>
        /// Returns true if there is at least a duplicate in the array.
        /// </summary>
        /// <returns></returns>
        static bool AnyDuplicate(int[] numbers)
        {            
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        return true; 
                    }
                }
            }
            return false;
