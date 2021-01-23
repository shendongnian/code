    static void Main()
        {
            var a = serialize.Deserialize<Root>("input.xml"); //xml file name given here.
            Console.WriteLine(a.contacts);
        }
