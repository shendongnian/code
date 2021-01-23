    private string DateToHex(DateTime theDate)
    {
        string isoDate = theDate.ToString("yyyyMMddHHmmss");
 
        string resultString = string.Empty;
        for (int i = 0; i < isoDate.Length ; i++)    // Amended
        {
            int n = char.ConvertToUtf32(isoDate, i);
            string hs = n.ToString("x");
            resultString += hs;
	 
        }
        return resultString;
    }
