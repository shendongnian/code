    Table table1;
    static void Main(string[] args)
    {
        //Table table1;  //instead of defining variable in a method, define it in class level.
        table1 = new Table();
    }
    private static void Generate(/*required arguments*/)
    {
        //Here you can access table1:
        Console.WriteLine(table1.ToString());
    }
 
