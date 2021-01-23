    static void Main(string[] args)
    {
        int[] Array=new int[]{10,233,34};
        int _MaxVal = CalculateMax(Array);
        Console.WriteLine(_MaxVal);
        Console.ReadKey();
    }
    private static int CalculateMax(int[] Array)
    {
        if (Array.Length > 0)
        {
            int maxSubArray = CalculateMax(Array.SubArray(1)); // Use recursive function on the SubArray starting at index 1 (that the smaller problem)
            if (maxSubArray > Array[0])
            {
                return maxSubArray;
            } else {
                return Array[0];
            }
        } else {
            return 0; // Stop test
        }
    }
