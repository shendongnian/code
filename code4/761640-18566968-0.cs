        string[] cSplitted = ";1234.jpg;1356.jpg;7890.jpg".Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach(string cString in cSplitted)
        {
            Console.WriteLine(cString);
        }
        Console.ReadLine();
