    public static Person Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            throw new ArgumentException("s cannot be null or empty", "s");
    
        string[] parts = s.Split(new char[] { ' ' }, 2);
        Person p = new Person { FirstName = parts[0] };
        if (parts.Length > 1)
            p.LastName = parts[1];
    
        return p;
    }
