    public string FullName
    {
        // This is assuming you've also fixed the property names to be conventional
        // I'd also suggest changing "Name" to "GivenName" or "FirstName".
        get { return string.Format("{0} {1} {2}", Name, LastName, Age); }
    }
