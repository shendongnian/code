    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3 };
        PickElements(0, arr);
    }
    static void PickElements<T>(int depth, T[] arr, int mask = -1)
    {
        int bits = Math.Min(32, arr.Length);
        // keep just the bits from mask that are represented in arr
        mask &= ~(-1 << bits); 
        if (mask == 0) return;
        // UI: write the options
        for (int i = 0; i < depth; i++ )
            Console.Write('>'); // indent to depth
        for (int i = 0; i < arr.Length; i++)
        {
            if ((mask & (1 << i)) != 0)
            {
                Console.Write(' ');
                Console.Write(arr[i]);
            }
        }
        Console.WriteLine();
        // recurse, taking away one bit (naive and basic bit sweep)
        for (int i = 0; i < bits; i++)
        {
            // try and subtract each bit separately; if it
            // is different, recurse
            var childMask = mask & ~(1 << i);
            if (childMask != mask) PickElements(depth + 1, arr, childMask);
        }
    }
