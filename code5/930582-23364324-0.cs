    class Program
    {
        static void Main(string[] args)
        {
            TypeLibInfo tli = new TypeLibInfo();
            tli.ContainingFile = @"c:\windows\system32\mshtml.tlb";
            foreach (TypeInfo ti in tli.TypeInfos)
            {
                Console.WriteLine(ti.Name);
                // etc...
            }
        }
    }
