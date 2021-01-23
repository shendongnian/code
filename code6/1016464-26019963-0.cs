    public readonly MyEnumOne E1;
    public readonly MyEnumTwo E2;
    private MyClass(MyEnumOne e1)
    {
        E1 = (MyEnumTwo)Enum.Parse(typeof(MyEnumTwo), e1);
    }
