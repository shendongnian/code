    public static class Translations
    {
        private static Dictionary<string, Dictionary<string, string>> languageAndTranslations = ...; // load from the database in your Global_asax
        public static string GetTranslation(string key)
        {
            return languageAndTranslations[HttpContext.Current.Session["language"]][key];
        }
    }
