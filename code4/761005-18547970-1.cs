    public static bool ExistInURL2(params object[] ob)
    {
        int ix = 0;
        bool ret;
        while (ix < ob.Length)
        {
            if (ob[ix] == null || ob[ix].ToString().Trim() == string.Empty)
            {
                ret = false;
                goto Label_004B;
            }
            ix++;
        }
        ret = true;
    Label_004B:
        return ret;
    }
