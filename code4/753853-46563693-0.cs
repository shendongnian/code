    string test = "۱۰۳۶۷۵۱";
    string EnglishNumbers = "";
    for (int i = 0; i < y.Length; i++)
    {
         EnglishNumbers += char.GetNumericValue(y, i);
    }
    int convertednumber = Convert.ToInt32(EnglishNumbers);
