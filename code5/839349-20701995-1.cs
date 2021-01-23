    public override bool Equals(System.Object obj)
    {
        if (obj == null)
            return false;
        
		Person p = obj as Person;
        if ((System.Object)p == null)
        	return false;
        return (id == p.id) && (name == p.name);
    }
    public bool Equals(Person p)
    {
        if ((object)p == null)
            return false;
        
		return (id == p.id) && (name == p.name);
    }
	public override int GetHashCode()
    {
        return id.GetHashCode() ^ name.GetHashCode();
    }
