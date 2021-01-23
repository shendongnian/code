    static void Main(string[] args)
    {
        TreeNodeParser nodeParser = new TreeNodeParser();
        using (Stream readStream = new FileStream(Path.Combine(Environment.CurrentDirectory, "TestFile.xml"), FileMode.Open, FileAccess.Read))
        {
            var node = nodeParser.FromStream<Node>(readStream);
            Console.WriteLine("{0}", node.ToString());
        }
        Console.ReadLine();
    }
