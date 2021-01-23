    void Main()
    {
        var a = new[] { 1, 2, 3 };
        Test(a);
        a.Dump();
    }
    
    public static void Test(int[] arr)
    {
        arr[1] = 15;
    }
