    var list = Periods.Select(p => p.Id).ToList();
    list.Sort(MyCustomComparison);
    ....
    private static int MyCustomComparison(string x, string y)
    {
       ... your comparing logic here.
    }
