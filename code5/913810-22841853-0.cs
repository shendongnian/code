    // When designing public methods you'd rather give to the parameters more
    // descriptive names than "a", "b", "c"
    public string Replace(string a, string b, string c) 
    {
        if ((a == null) || (b == null) || (c == null))
          return a;
       
        return a.Replace(b, c); 
    }
