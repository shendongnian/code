    public int calc(Values vals)
    {
      vals.getSetNum = 6;
      Console.WriteLine(vals.getSetNum);
      return vals.getSetNum;
    }
    static void Main(string[] args)
    {
        Program prog = new Program();
        Values val = new Values();
        prog.calc(val);                     //Outputs 6 
        Console.WriteLine(val.getSetNum); //Outputs 6 
        Console.ReadKey();
    }
