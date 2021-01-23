    public string Translate(string input)
    {
        if(_dictionary.ContainsKey(input))
            return _dictionary[input];
        throw new Exception("Sinatra doesn't know this ditty");
    }
