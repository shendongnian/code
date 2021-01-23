    public string Serialize(Test test)
    {
        var document =
            new XDocument(
                new XElement("Test",
                    new XElement("A", test.M.A),
                    new XElement("B", test.M.B)));
                 
        return document.ToString();
    }
    var test = new Test {  M = new MyClass { A = 1, B = 2 } };
    Console.WriteLine(Serialize(test));
