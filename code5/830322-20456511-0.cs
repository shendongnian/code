    [STAThread]
    private static void Main()
    {
    
        Option tested = Option.Paul;
        Program p4 = new Program(Option.Paul, Option.Paul, Option.Paul);
        Console.WriteLine("4: " + p4.UniqueOption(tested));
    
    }
    public Option? UniqueOption(Option tested)
    {
        if (optionList.All(o => o.Option == tested))
            return tested;
    
        return null;
    }
