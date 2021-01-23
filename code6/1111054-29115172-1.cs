    private static void Extract<T>(T param)
    {
        string name = ((dynamic)param).Name;
    }
    private static void Extract<T>(T[] param)
    {
        for (int i = 0; i < param.Length; i++)
        {
            string name = ((dynamic)param[i]).Name;
        }
    }
