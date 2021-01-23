    Console.WriteLine((Array.CreateInstance(typeof(int), new[] { 1 }, new[] { -1 })).GetType());
    Console.WriteLine((Array.CreateInstance(typeof(int), new[] { 1 }, new[] { 0 })).GetType());
    Console.WriteLine((new int[] {}).GetType());
    // yields:
    // System.Int32[*]
    // System.Int32[]
    // System.Int32[]
    (int[])Array.CreateInstance(typeof(int), new[] { 1 }, new[] { -1 })
    // throws:
    // System.InvalidCastException
