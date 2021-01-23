    public static void ReadFile1(ref int? x)
    {
        System.IO.StreamReader file1 = new System.IO.StreamReader( {FILEDESTINATION});
        x = int.Parse(file1.ReadLine());
    }
