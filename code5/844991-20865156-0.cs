    using (StreamReader r = new StreamReader("test.txt")) 
    {
        int counter = 1;
        string line = r.ReadLine();
        while (line != null) 
        {
            Console.WriteLine (counter.ToString() + ": " + line);
            counter++;
            line = r.ReadLine ();
        }
    }
