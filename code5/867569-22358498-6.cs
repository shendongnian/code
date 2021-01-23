    public static bool operator ==(Foo a, Foo b)
    {
        if (object.ReferenceEquals(a, b))
        {
            return true;
        }
        else if (object.ReferenceEquals(a, null))
        {
            return !b.Result;
        }
        else if (object.ReferenceEquals(b, null))
        {
            return !a.Result;
        }
        else
        {
            return a.Result == b.Result;
        }
    }
