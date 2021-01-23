    string Connectionstring="Data Source=;Initial Catalog=abc;Persist Security Info=True;
    User ID=dsds;Password=dsdsd;MultipleActiveResultSets=True";
     public Sales()
            : base("name=Sales")
        {                                                                        
        }
            public Sales(string Connectionstring)
                : base(Connectionstring)
            {
            }
