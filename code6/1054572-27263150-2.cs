         public string ConcatenatedName
                {
                    get
                    {
                        return string.format("{0} {1} {2}",FirstName, LastName, Suffix) 
                    }
                }
    
     public string FirstName
            {
                get { return _firstName; }
                set { _firstName = value;}
            }
    
    
     public string LastName
            {
                get { return _lastName; }
                set { _lastName = value;}
            }
    
    
     public string Suffix
            {
                get { return _suffix; }
                set { _suffix = value;}
            }
