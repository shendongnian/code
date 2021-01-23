    public bool IsValid // consider better name here
    {
        get
        {
             return !String.IsNullOrEmpty(Firstname) &&
                    !String.IsNullOrEmpty(Lastname) &&
                    !String.IsNullOrEmpty(Email) &&
                    !String.IsNullOrEmpty(Username);           
        }
    }
