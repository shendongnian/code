    public enum DecimailPrecision
    {
        [EnumCode("#,##0.0")]
        One,
        [EnumCode("#,##0.00")]
        Two
    }
    string format = DecimailPrecision.One.GetCode();
