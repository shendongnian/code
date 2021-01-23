    public static class LocalizationExtensions
    {
        public static string t(this string translate)
        {
            return NSBundle.MainBundle.LocalizedString(translate, "", "");
        }
    }
How do I get it to choose Icelandic as the language since iOS does not have it as an available language?
