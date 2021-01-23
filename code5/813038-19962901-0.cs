    public List<string> FirstNames
    {
        get
        {
           return _contactList.Select(C => C.FirstName).ToList();
        }
    }
