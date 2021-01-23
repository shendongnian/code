    public override bool Equals(Object obj)
    {
        Class cs = (MyClass)obj;
        return UserName == cs.UserName && 
               IsUserEmployed  = cs.IsUserEmployed &&
               IsUserValid == cs.IsUserValid;
    }
