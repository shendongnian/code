    public static bool ExistInURL3(params object[] ob)
    {
        int ix = 0;
        while (ix < ob.Length)
        {
            if (ob[ix] == null || ob[ix].ToString().Trim() == string.Empty)
            {
                return false;
            }
            ix++;
        }
        return true;
    }
