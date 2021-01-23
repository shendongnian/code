    static void Main(string[] args)
    {
        var a = "asdas"+(char)847;//add a hidden character
        var b = "asdas";
        Console.WriteLine(a.Equals(b)); //false
        Console.WriteLine(a.CompareTo(b)); //0
        Console.WriteLine(a.Length); //6
        Console.WriteLine(b.Length); //5
       //watch window shows both a and b as "asdas"
    }
