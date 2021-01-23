    public enum ParentEnum
    {
        A1 = 1, A2 = 2,
        B1 = 100, B2 = 101
    }
    public enum AEnum
    {
        A1 = ParentEnum.A1,
        A2 = ParentEnum.A2
    }
