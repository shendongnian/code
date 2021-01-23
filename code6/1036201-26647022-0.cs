    // TODO: Change *all* the names to be meaningful and comply with conventions
    public int calc()
    {
        Values vals = new Values();
        vals.getSetNum = 6;
        Console.WriteLine(vals.getSetNum);
        return vals;
    }
    static void Main(string[] args)
    {
        Program prog = new Program();
        Values val = prog.calc();
        Console.WriteLine(val.getSetNum);
    }
