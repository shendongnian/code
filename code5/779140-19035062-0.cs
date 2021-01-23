    public override String foo(M m)
    {
        if (m == null) { throw new ArgumentNullException("m"); }
        N n = m as N;
        if (n == null) { throw new ArgumentException("Must be an N instance.", "m"); }
        return foo(n);
    }
    public virtual String foo(N n)
    {
        // Use the n variable
    }
