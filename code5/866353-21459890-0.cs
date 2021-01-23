    public int? DecimalAfter (string strDec, out decimal? decNull)
    {
        int? decAfter = null;
        strDec = strDec.Trim();
        decimal dec;
        if (decimal.TryParse(strDec, out dec))
        {
            decNull = dec;
            int decPos = strDec.IndexOf('.');
            if (decPos == -1)
            {
                decAfter = 0;
            }
            else
            {
                decAfter = strDec.Length - decPos - 1;
            }
        }
        else decNull = null;
    
        return decAfter;
    }
  
