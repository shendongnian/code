    public void AssignIfNull<T>(ref T target, T value)
    {
        if(target == null) target = value;
    }
    // ...
    AssignIfNull(ref a, b);
