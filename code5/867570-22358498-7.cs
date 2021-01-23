    public override int GetHashCode()
    {
        return this.Result ? 1 : 0;
    }
    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(obj, null))
        {
            return !this.Result;
        }
        Type t = obj.GetType();
        if (t == typeof(Foo))
        {
            return this.Result == ((Foo)obj).Result;
        }
        else if (t == typeof(bool))
        {
            return this.Result == (bool)obj;
        }
        else
        {
            return false;
        }
    }
