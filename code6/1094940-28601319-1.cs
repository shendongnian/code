    public static int Count(string txt)
    {
        // TODO validation etc
        var result = 0;
        char lstChr = txt[0];
        int lastChrCnt = 1;
    
        for (var i = 1; i < txt.Length; i++)
        {
            if (txt[i] == lstChr)
            {
                lastChrCnt += 1;
            }
            else
            {
                if (lastChrCnt == 3)
                {
                    result += 1;
                }
    
                lstChr = txt[i];
                lastChrCnt = 1;
            }
        }
    
        return lastChrCnt == 3 ? result + 1 : result;
    }
