    public void Init(IDictionary<string, object> dict)
    {
        double val;
        
        if (!double.TryParse(dict[MY_KEY].ToString(), out val))
        {
            // Handle parse failure if necessary.
            // On failure, the return value of val will be 0
        }   
    }
