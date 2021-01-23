    static void Main(string[] args)
    {
        int[] a = { 120, 60, 50, 40, 30, 20 };
        int[] b = { 12, 29, 37, 85, 63, 11 };
        int[] c = { 30, 23, 90, 110, 21, 34 };
    
        var indexes = Enumerable.Range(0, a.Length).OrderBy(i => a[i]).ToArray();
    
        var temp = new int[a.Length];
        foreach (var arr in new[] { a, b, c })
        {
            for (int i = 0; i < a.Length; i++) temp[i] = arr[indexes[i]];
            for (int i = 0; i < a.Length; i++) arr[i] = temp[i];
        }
    
        Console.WriteLine(String.Join(", ", a));
        Console.WriteLine(String.Join(", ", b));
        Console.WriteLine(String.Join(", ", c));
        Console.ReadLine();
    }
