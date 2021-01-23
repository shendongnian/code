    public Something()
    {
        someObject = new SomeObject();  //let's say this takes 350ms
    }
    public byte[] DoIt(byte[] bytes)
    {
        return someObject.ComputeHash(bytes);  //let's say this takes 3ms
    }
