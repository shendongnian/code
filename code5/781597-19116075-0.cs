    public static string StrReplace(string cSearchExpression, string replacement, string cBeginDelim, string cEndDelim, int nBeginOccurence)
        {
            string cstring = cSearchExpression;
            string cb = cBeginDelim;
            string ce = cEndDelim;
            if (cSearchExpression.Contains(cBeginDelim) == false && cSearchExpression.Contains(cEndDelim) == false)
            {
                return cstring;
            }
            //Lookup the position in the string
            int nbpos = At(cb, cstring, nBeginOccurence) + cb.Length - 1;
            int nepos = cstring.IndexOf(ce, nbpos + 1);
            //Reaplce the part of the string if we get it right
            if (nepos > nbpos)
            {
                cstring = cstring.Remove(nbpos, nepos - nbpos).Insert(nbpos, replacement);
            }
            return cstring;
        }
