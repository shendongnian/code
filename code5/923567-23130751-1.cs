    IEnumerable<string> GetNextChars ( string str, int iterateCount )
    {
        var words = new List<string>();
        for ( int i = 0; i < str.Length; i += iterateCount )
            if ( str.Length - i >= iterateCount ) words.Add(str.Substring(i, iterateCount));
            else words.Add(str.Substring(i, str.Length - i));
        return words;
    }
