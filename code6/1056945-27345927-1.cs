    String[] languages = new String[] { "english", "french", "german"};
    string line1 = File.ReadLines("MyFile.txt").First(); // gets the first line from file.
    if(languages.Contains(line1)) // check if first line matches specified languages
    {
        // success
        Console.WriteLine("Language is {0}", line1);
    }
    else
    {
        // fail
        Console.WriteLine("Language not found: {0}", line1);    
    }
