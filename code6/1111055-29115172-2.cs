    private static void Extract<T>(T param, Func<T, string> getName)
    {
        string name = getName(param);
    }
    private static void Extract<T>(T[] param, Func<T, string> getName)
    {
        for (int i = 0; i < param.Length; i++)
        {
            string name = getName(param[i]);
        }
    }
