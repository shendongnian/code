    [Flags]
    public enum EntityStatus
    {
        NoneIsOK = 0,
        FirstIsOK = 1,   // = 2^0
        SecondIsOK = 2,  // = 2^1
        BothAreOK = FirstIsOK | SecondIsOK;
    }
