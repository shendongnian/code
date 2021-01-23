    static void Main(string[] args)
    {
        int[] a = { 1, 90, 3, 4, 0, 6 };
        int small,big;
        float avg=0;
        small = a[0];
        big = a[0];
        for (int i = 0; i < a.Length; i++) //O(n) executed n times only
        {
            if (small > a[i])
                small = a[i];
            if (big < a[i])
                big = a[i];
            avg += a[i];
        }
        avg = avg / a.Length;
        Console.WriteLine("smallest= " + small + "  largest= " + big + "  Average= " + avg);
        Console.ReadKey();
    }
