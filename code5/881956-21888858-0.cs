    public async Task SlowPrint(string fileName)
    {
        //TODO stuff to generate real file path and check if it exists
        foreach(var line in File.ReadLines(fileName))
        {
            Console.WriteLine(line);
            await Task.Delay(700);
        }
    }
