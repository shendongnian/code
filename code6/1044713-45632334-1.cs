    /// <summary>
    /// auto generate a array with number element and max value is max
    /// </summary>
    /// <param name="number">number element of array</param>
    /// <param name="max">max value of array</param>
    /// <returns>array of number</returns>
    public static int[] createRandomArray(int number, int max)
    {
        List<int> ValueNumber = new List<int>();
        for (int i = 0; i < max; i++)
            ValueNumber.Add(i);
            int[] arr = new int[number];
            int count = 0;
            while (count < number)
            {
                Random rd = new Random();
                int index = rd.Next(0,ValueNumber.Count -1);
                int auto = ValueNumber[index];
                arr[count] = auto;
                ValueNumber.RemoveAt(index);
                count += 1;
            }
            return arr;
        }
    }
 
