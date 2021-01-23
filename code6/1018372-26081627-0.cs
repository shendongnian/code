    public static TextReader _namefile;
    static void Main(string[] args)
    {
        _namefile = new StreamReader(@"E:\Code in C Sharp\read-file\read-file\test.txt");
        string line = _namefile.ReadLine();
        Console.WriteLine(line);
        Console.ReadLine();
        ////Read second line
        string line1 = _namefile.ReadLine();
        Console.WriteLine(line1);
        Console.ReadLine();
    }
    static public string[] Returnval(string line)
    {
        string line1 = _namefile.ReadLine();
        var Returnval = line.Split('\t');
        return Returnval;
    }
