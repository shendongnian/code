    public Users[] Search(string name) {
        // A factory would be a better option.  This should also be an interface.
        Company.SearchParameters searchParams = new Company.SearchParameters(name);
        
        // Your logic here
    }
