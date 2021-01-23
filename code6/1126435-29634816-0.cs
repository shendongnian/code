    public static int[] GetArray(int sum, int n)
    {
        if(sum < n)
            throw new ArgumentException("sum is lower than n");
        Random rnd = new Random();
        // reserve 1 for each of the elements
        sum -= n;
        // generate random weights for every element in sum
        int[] w = new int[n];
        int sw = 0;             
        for (int i = 0; i < n; i++)
        {
            w[i] = rnd.Next(0, 100);
            sw += w[i];
        }
        // generate element values based on their weights
        int[] result = new int[n];
        int tsum = 0;
        int psum = 0;
        for (int i = 0; i < n; i++)
        {
            tsum += w[i] * sum;
            result[i] = tsum / sw - psum;
            psum += result[i];
        }
        // restore reserved ones
        for (int i = 0; i < n; i++)
            result[i]++;
        return result;
    }
