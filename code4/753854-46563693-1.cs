    string test = "۱۰۳۶۷۵۱";
    string EnglishNumbers = "";
    for (int i = 0; i < test.Length; i++)
    {
         EnglishNumbers += char.GetNumericValue(test, i);
    }
    int convertednumber = Convert.ToInt32(EnglishNumbers);
