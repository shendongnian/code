    public static LanguageEnum GetLanguage(string[] languages)
    {
        if (languages == null) return DefaultLanguage;
        LanguageEnum lang = DefaultLanguage;
        bool firstDone = false;
        foreach (string language in languages)
        {
            string realLanguage = Regex.Replace(language, "[;q=(0-9).]", "");
            LanguageEnum givenlang = GetLanguage(realLanguage);//converts it to an enum, overload method.
            //first one should be the used language that is set for a browser (if user did not change it their self).
            //In some browsers their might be multiple languages (for translations)
            if (!firstDone)
            {
                firstDone = true;
                lang = givenlang; 
            }
            else
            {
                //ranking others
                lang = RankLanguage(lang, givenlang);
            }
           
        }
        return lang;
    }
    private static LanguageEnum RankLanguage(LanguageEnum existing, LanguageEnum newLnag)
    {
        if (existing == LanguageEnum.EN && newLnag != LanguageEnum.EN)
        {
            //everything that is other then english gets a higher rank
            return newLnag;
        }
        //add other usecases here specific to your application/use case, keep in mind that all other languages could pass
        return existing;
    }
    //below code is for setting the language culture I use, 
    //fixed number and date format for now, this can be improved.
    //might be if your interests if you want to use parameterized languages
        public static void SetLanguage(LanguageEnum language)
        {
            string lang = "";
            switch (language)
            {
                case LanguageEnum.NL:
                    lang = "nl-NL";
                    break;
                case LanguageEnum.EN:
                    lang = "en-GB";
                    break;
                case LanguageEnum.DE:
                    lang = "de-DE";
                    break;
            }
            try
            {
                NumberFormatInfo numberInfo = CultureInfo.CreateSpecificCulture("nl-NL").NumberFormat;
                CultureInfo info = new CultureInfo(lang);
                info.NumberFormat = numberInfo;
                //later, we will if-else the language here
                info.DateTimeFormat.DateSeparator = "/";
                info.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                Thread.CurrentThread.CurrentUICulture = info;
                Thread.CurrentThread.CurrentCulture = info;
            }
            catch (Exception)
            {
            }
        }
