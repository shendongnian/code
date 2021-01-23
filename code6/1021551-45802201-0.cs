         public static decimal? Todecimal(string s,decimal defValue=0)
        {
            if (s.Trim()!="")
            {
                return Convert.ToDecimal(s);
            }
            else
            {
                return defValue;
            }
        }
