          protected override void InitializeCulture()
    {
         string language = Request["__EventTarget"];
     if (!string.IsNullOrEmpty(language))
            {
                if (language.EndsWith("Ar"))
                {
                    languageId = "ar-SA";
                }
                else if (language.EndsWith("En"))
                {
                    languageId = "en-US";
                }
           }
             
