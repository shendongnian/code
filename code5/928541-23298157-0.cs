    public void PerformStringOperation(string str1, string str2)
    {
        if(string.IsNullOrEmpty(string1))
            throw new ArgumentNullException(...);
        if(string.IsNullOrEmpty(string2))
            throw new ArgumentNullException(...);
       // Execute code here
    }
