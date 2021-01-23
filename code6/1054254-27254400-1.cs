    private MyObject _mine;
    public SomeConstructor(MyObject mine)
    {
        _mine = ThrowOn.Null(mine, "mine");
    }
