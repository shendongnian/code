    static void Main(string[] args)
    {
        var a = "asdas\u0000";
        var b = "asdas";
        Console.WriteLine(a.Equals(b));//false
        Console.WriteLine(a.CompareTo(b));//0
        Console.WriteLine(a.Length);//6
        Console.WriteLine(b.Length);//5
    }
