    public void ToFile(StreamWriter sw)
    {
        sw.AutoFlush = true;
        Console.SetOut(sw);
        Console.WriteLine("Regression Test Performed at {0}", thisDate);
        Console.WriteLine("-----");
    }
    
    
    [Test]
    public void NewTextFile()
    {
        using (var sw = new StreamWriter(FileName, true))
        {
            ToFile(sw);
            const int requiredNumber = 5;
            for (var i = 0; i < requiredNumber; i++)
            {
                Console.WriteLine("New ID assigned to ABC");
                Console.WriteLine("-----");
            }
        }
    }
