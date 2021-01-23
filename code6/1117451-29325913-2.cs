    // CHANGED: Removed n as parameter (n just the index of summation here)
    public static BigRational Series(int k, int p)
    {
        BigRational series = new BigRational(0.0);
        var fin = k - 1;
        // CHANGED: Should be <= fin (i.e. <= k-1, or < k) because it's inclusive counting
        for (int i = 0; i <= fin; i++)
        {
            var power = BigRational.Pow(p, i);
            // CHANGED: was Factorial(n), should be factorial of n value in this part of the sequence being summed.
            var factorialN = Factorial(i);
            var sum = BigRational.Divide(power, factorialN);
            series += sum;
        }
        return series;
    }
