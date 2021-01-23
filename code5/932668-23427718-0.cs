    public HashSet<char> SomeCharacters(IEnumerable<string> _hashes){
    
        string first = _hashes.FirstOrDefault();
        if(first == null) return new HashSet<char>();
        
        HashSet<char> Result = new HashSet<char>(first);
    
        foreach (string _hash in _hashes.Skip(1)) {
            // ...
            // some code that uses Result
        }
        return Result;
    }
