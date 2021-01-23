    class Program
    {
        static void Main(string[] args)
        {
            var childBuilder = new DataBuilderChild().WithId(1).WithDescription("Child");
            MyParent parent = childBuilder;
            MyChild child = childBuilder;
            Console.WriteLine(@"Parent With Id {0}", parent.Id);
            Console.WriteLine(@"Child With Id {0} and Desciprtion - {1}", child.Id, child.Description);
            Console.ReadKey();
        }
    }
