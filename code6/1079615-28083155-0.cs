    public void MethodA(object someObject, int a, int b)
    {
        if (someObject == null)
            throw new ArgumentNullException();
    
        MethodB(a, b);
        MethodC(b, a); // Possibility of OverflowException,
    }
    
    public void MethodAA(object someObject, int a, int b)
    {
        if (someObject == null)
            throw new ArgumentNullException();
    
        MethodB(a, b);
        MethodC(b, b); // No Possibility of OverflowException,
    }
    internal int MethodB(int a, int b)
    {
        return a/b; // This can throw DivideByZeroException
    }
    
    public int MethodC(int a, int b)
    {
        retirm a - b; // This can cause Overflow exception.
    }
