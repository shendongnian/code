    [return: MarshalAs(UnmanagedType.Currency)]
    public decimal GetDecimalFromNetDll()
    {
        decimal value = ... // Read from database
        return value;
    } 
    public void SetDecimalInNetDll([MarshalAs(UnmanagedType.Currency)] decimal value)
    {
        // Save to database
    }
