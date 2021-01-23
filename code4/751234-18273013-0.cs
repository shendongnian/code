    Dictionary<string, string> EnglishHindiTranslations = null;
    public void Populate()
    {
        EnglishHindiTranslations = new Dictionary<string, string>();
        EnglishHindiTranslations.Add("my","mera");
        EnglishHindiTranslations.Add("is","hai");
        EnglishHindiTranslations.Add("Name","naam");
    }
    public string TranslateHindiToEnglish(string hindiWord)
    {
        string value = EnglishHindiTranslations.FirstOrDefault(x => x.Value == hindiWord).Key;
   
        if(string.IsNullOrEmpty(value))
        {
             return hindiWord;
        }
        return value;
     }
    public string TranslateEnglishToHindi(string englishWord)
    {
        string value = EnglishHindiTranslations.FirstOrDefault(x => x.Key == englishWord).Value;
	
        if(string.IsNullOrEmpty(value))
        {
             return englishWord;
        }
        return value;
    }
