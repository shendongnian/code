    [Fact]
    public void Test()
    {
        Serialize<DataContract>(new KnownType1 { Value = 1, Value1 = 2 });
        Serialize<DataContract>(new DataContract { Value = 1 });
    }
