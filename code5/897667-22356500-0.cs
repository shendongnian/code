    public const MagicNumberPropertyName = "MagicNumber";
    public enum Operator
    {
        Equals
    }
    [AppAuthorization(MagicNumberPropertyName, Operator.Equals, 13)]
    protected void Method() {}
