    public string Translate(string input)
    {
        string output;
        if(_dictionary.TryGetValue(input, out output))
            return output;
        // Obviously you might not want to throw an exception in this basis example,
        // you might just go return "ERROR".  Up to you, but those requirements are
        // beyond the scope of the question! :)
        throw new Exception("Sinatra doesn't know this ditty");
    }
