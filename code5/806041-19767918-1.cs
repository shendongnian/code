    // Might return null, better to use try catch
    public static Animals GetEnum(string val)
    {
        return (Animals)Enum.Parse(typeof(Animals), val, true);
    }
    
    public static string GetName(Animals an)
    {
        return Enum.GetName(typeof(Animals), an);
    }
    public static string GetReplace(Animals an)
    {
        var get = GetName(an);
        var tempstr = "";
        int getch = 0;
        foreach (var chr in get.ToCharArray())
        {
            if (chr == chr.ToUpper())
            {
                getch++;
                // Second up value char
                if (getch == 2)
                {
                    tempstr += "_" + chr;
                }
                else
                {
                    tempstr += chr;
                }
            }
            else
            {
                 tempstr += chr;
            }
        }
        return tempstr;
    }
