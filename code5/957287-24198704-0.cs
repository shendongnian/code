    public override bool Equals(Class1 cs)
    {
        return UserName == cs.UserName && 
               IsUserEmployed  = cs.IsUserEmployed &&
               IsUserValid == cs.IsUserValid;
    }
