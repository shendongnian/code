    public int SumAll(int number)
    {
        // Base case
        if (number == 1)
        {
            return 1;
        }
        
        // Recursive call
        return number + SumAll(number - 1);
    }
