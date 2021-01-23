    class Program
    {
        static void Main(string[] args)
        {
            AbcXyzWork work = new AbcXyzWork();
            AbcStep abcStep = new AbcStep(work);
            AbcXyzStep abcxyzStep = new AbcXyzStep(work);
            AssemblyLineService line = new AssemblyLineService();
            line.ExecuteAll(new IAssemblyLineItem[] { abcStep, abcxyzStep });
            Console.ReadLine();
        }
    }
