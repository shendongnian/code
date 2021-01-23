    bool b;
    int tempNumber;
    foreach (string line in lines)
    {
        string[] words = line.Split(' ');
        foreach (string word in words)
        {
            b = Int32.TryParse(word, out tempNumber);
            if (b) // success
            {
                tab[i] = tempNumber;
                Console.WriteLine(tab[i]);
                i++;
            }
            else // handle error
            {
               Console.WriteLine("Error: '" + word + "' could not be parsed as an Int32");
            }
        }
    }
