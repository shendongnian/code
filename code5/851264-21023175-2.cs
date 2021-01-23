    public IEnumerable<string> SomeMethod(int NumberOfChars) 
    {
        if (NumberOfChars == 1)
            return Enumerable.Range('a', 26).Select(x => ((char)x).ToString());
    	else
            return Enumerable.Range('a', 26).SelectMany(x => SomeMethod(NumberOfChars - 1).Select(s => ((char)x) + s));
    }
