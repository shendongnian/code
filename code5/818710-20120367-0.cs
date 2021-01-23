    class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    
    void ByRef(ref User user)
    {
        user = new User();
    }
    
    void ByVal(User user)
    {
        user = new User();
    }
    
    void Test()
    {
        var user = null;
        ByVal(user);
        // user is still null
        ByRef(ref user);
        // user is new User()
    }
