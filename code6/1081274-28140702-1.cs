    public static Blower[] _Blower = new Blower[4];
    public static void InstantiateBlowerObj()
    {
        for (int i = 1; i < 4; i++)
            _Blower[i] = new Blower(i);
    }
