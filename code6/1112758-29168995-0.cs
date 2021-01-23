    using (var sr = new StringReader(textFromFile))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
           // sth with a line
        }
    }
