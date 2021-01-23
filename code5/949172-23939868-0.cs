    enum MyEnum
    {
        Zero,
        One,
        Two,
        Ten = 10
    }
    MyEnum e;
    Enum.TryParse<MyEnum>("10", out e);
    // success; e == MyEnum.Ten
    MyEnum e;
    Enum.TryParse<MyEnum>("11", out e);
    // success; e == (MyEnum)11
