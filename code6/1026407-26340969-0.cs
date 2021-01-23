    public void ToFile()
    {
        using (var sw = new StreamWriter(FileName, true))
        {
            sw.AutoFlush = true;
            Console.SetOut(sw);
            Console.WriteLine("Regression Test Performed at {0}", thisDate);
            Console.WriteLine("-----");
        }
    }
    [Test]
    public void NewTextFile()
    {
        ToFile();
        const int requiredNumber = 5;
        for (var i = 0; i < requiredNumber; i++)
        {
            Console.WriteLine("New ID assigned to ABC");
            Console.WriteLine("-----");
        }
    }
