    public static string GetCode(this SomeEnum aSomeEnum)
    {
        switch (aSomeEnum)
        {
            case SomeEnum.Foo: return "Foo";
            case SomeEnum.Bar: return "Bar";
            case SomeEnum.Baz: return "Baz";
            default: throw new InvalidEnumArgumentException("aSomeEnum", (int)aSomeEnum, typeof(SomeEnum));
        }
    }
