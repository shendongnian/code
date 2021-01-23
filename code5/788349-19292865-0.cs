    static void Main(string[] args)
        {
            Hashtable collection = new Hashtable();
            collection["integer"] = 123;
            collection["double"] = 456.78;
            collection["string"] = "Hello world!";
            double sum = (double)(int)collection["integer"] + (double)collection["double"];
            Console.WriteLine("The sum of all numbers is {0}", sum);
            Console.WriteLine();
        }
