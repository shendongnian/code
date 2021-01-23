    static void Main(string[] args)
    {
        var list = new[] {"1st street","2 burritos","Allergy","Ameripath","Application","APK THD"};
        list.OrderBy(x => x, StringComparer.Ordinal).ToList().ForEach(Console.WriteLine);
    }
