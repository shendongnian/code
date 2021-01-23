    public override bool Equals(Object obj)
    {
        return obj is User && Equals((User)obj);
    }
    
    public bool Equals(User other)
    {
        return UserGuid == other.UserGuid && Username == other.Username;
    }
    
    public static bool operator ==(User lhs, User rhs)
    {
        return lhs.Equals(rhs);
    }
    
    public static bool operator !=(User lhs, User rhs)
    {
        return !lhs.Equals(rhs);
    }
