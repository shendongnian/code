    using (StreamReader sr = new StreamReader("TestFile.txt"))
    {
        String line = sr.ReadToEnd();
        Console.WriteLine(line);
    }
    Console.ReadLine();
    sr.Close();
