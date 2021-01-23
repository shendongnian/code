    static void Main(string[] args)
    {
        var temp = new Temp<People>();
        TestMethod(temp);
    }
    public static void TestMethod(ITemp<Organism> param)
    {
        param.SecondPrint(() => new Animal());
    }
