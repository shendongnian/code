    public static bool operator ==(Person a, Person b)
    {
        if (System.Object.ReferenceEquals(a, b))
            return true;
	
        if ((object)a == null || (object)b == null)
            return false;
	
        return a.id == b.id && a.name == b.name;
    }
	
    public static bool operator !=(Person a, Person b)
    {
        return !(a == b);
    }
