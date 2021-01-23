    public static bool operator ==(MyDynamic lhs, object rhs)
    {
        if (rhs is MyDynamic)
            return lhs.Equals(rhs);
        else
            return false;
    }
    public static bool operator !=(MyDynamic lhs, object rhs)
    {
        if (rhs is MyDynamic)
            return !lhs.Equals(rhs);
        else
            return true;
    }
    public static bool operator ==(object lhs, MyDynamic rhs)
    {
        if (lhs is MyDynamic)
            return lhs.Equals(rhs);
        else
            return false;
    }
    public static bool operator !=(object lhs, MyDynamic rhs)
    {
        if (lhs is MyDynamic)
            return !lhs.Equals(rhs);
        else
            return true;
    }
