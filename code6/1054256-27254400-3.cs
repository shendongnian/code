    private MyObject _mine;
    public SomeConstructor(MyObject mine)
    {
        _mine = mine.ThrowOnNull("mine");
    }
