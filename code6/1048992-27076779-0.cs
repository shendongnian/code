    public enum ErrorCode
    {
        NORMAL_STOP      = 0x00000000,
        LIB_BROKEN       = 0x000000a1,
        RESOURCE_MISSING = 0x000000a2,
        METHOD_NOT_FOUND = 0x000000a3,
        FRAMEWORK_ERROR  = 0x000000b1,
        UNKNOWN          = 0x000000ff
    }
    public string GetName(ErrorCode code)
    {
    }
