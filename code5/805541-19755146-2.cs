    public double variance()
    {
        // each (value - mean) squared
        double dMean - mean();
        double summationsTotal = 0; // (numbers[i] - mean() squared
    
        for (int i = 0; i < numbers.Length; i++)
        {
            summationsTotal += Math.Pow(numbers[i] - dMmean, 2);
        }
    
        return summationsTotal / (numbers.Length - 1);
    }
