    private int[,] array = { { 52, 76, 33}, { 98, 87, 93 }, { 43, 77, 62 }, { 72, 73, 74 } };
    public void ArraySum()
    {      
        int sum = 0;        
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)    
                sum += array[i, j];            
        }
        Console.WriteLine("The sum for the whole array is {0}: ", sum);
    }
