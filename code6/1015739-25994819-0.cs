    [Flags]
    public enum Colors : byte
    {
        Transparent = 0,                                         // = 0 (00000000)
        Red         = 1 << 0,                                    // = 1 (00000001)
        LightRed    = 1 << 1,                                    // = 2 (00000010)
        Pink        = 1 << 2,                                    // = 4 (00000100)
        Green       = 1 << 3,                                    // = 8 (00001000)
        RedLikes    = Colors.Red | Colors.LightRed | Colors.Pink // = 7 (00000111)
    }
