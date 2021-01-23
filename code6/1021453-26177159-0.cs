    public static int[] Plus(int[] a, int[] b, int size)
    {
        int[] sum = new int[size];
        for (int i = 0; i < size; i++)
        {
            sum[i] = a[i] + b[i];
        }
        return sum;
    }
    public static long[] Plus(long[] a, long[] b, int size)
    {
        long[] sum = new long[size];
        for (int i = 0; i < size; i++)
        {
            sum[i] = a[i] + b[i];
        }
        return sum;
    }
