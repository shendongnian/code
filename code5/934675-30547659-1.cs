    public static bool Isprime2(long number)
    {
        // Get the quick checks out of the way.
        if (number < 2) { return false; }
        // 2, 3, 5, & 7 are prime.
        if ((new long[] { 2L, 3L, 5L, 7L }).Contains(number)) { return true; }
        // any other multiples of 2 are not prime.
        if ((number % 2) == 0) { return false; }
        // any other multiples of 3 are not prime.
        if (number % 3 == 0) { return false; }
        // Quick checks are over.  Must iterate to find the answer.
        // Though the whole number portion of the square root of long.MaxValue
        // would fit in a uint, there is better performance inside the loop
        // if we don't need to implicitly cast over and over a few million times.
        long root = (long)Math.Sqrt(number);
        long factor = 5;
        while (factor <= root)
        {
            if (number % factor == 0L) { return false; }
            if (number % (factor + 2L) == 0L) { return false; }
            factor = factor + 6L;
        }
        return true;
    }
