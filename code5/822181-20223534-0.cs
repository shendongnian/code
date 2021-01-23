    private static void Main(string[] args)
    {
        IList<SomeClass> classes = new List<SomeClass>();
        using (var sc = new SomeClass())
        {
            sc.SomeList.Add("a");
            classes.Add(sc);
            using (var sc = new SomeClass())
             {
                sc.SomeList.Add("b");
                classes.Add(sc);
                foreach (var a in classes)
                {
                    Console.WriteLine(a.SomeList[0]);
                }
            }
        }
        Console.ReadLine();
    }
