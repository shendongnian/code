    public static bool IsPrime6(ulong number)
    {
        // Get the quick checks out of the way.
        if (number < 2UL) { return false; }
        // Dispense with multiples of 2 and 3.
        if ((number % 2UL) == 0UL) { return (number == 2UL); }
        if ((number % 3UL) == 0UL) { return (number == 3UL); }
    
        // Quick checks are over.  Must iterate to find the answer.
        // We loop over 1/6 of the required possible factors to check,
        // but since we check twice in each iteration, we are actually
        // checking 1/3 of the possible divisors.  This is an improvement
        // over the typical naive test of odds only which tests 1/2
        // of the factors.
    
        // Though the whole number portion of the square root of ulong.MaxValue
        // would fit in a uint, there is better performance inside the loop
        // if we don't need to implicitly cast over and over a few million times.
        ulong root = (ulong)(uint)Math.Sqrt((double)number);
        // Corner Case: Math.Sqrt error for really HUGE ulong.
        if (root == 0UL) root = (ulong)uint.MaxValue;
    
        // Start at 5, which is (6k-1) where k=1.
        // Increment the loop by 6, which is same as incrementing k by 1.
        for (ulong factor = 5UL; factor <= root; factor += 6UL)
        {
            // Check (6k-1)
            if ((number % factor) == 0UL) { return false; }
            // Check (6k+1)
            if ((number % (factor + 2UL)) == 0UL) { return false; }
        }
    
        return true;
    }
