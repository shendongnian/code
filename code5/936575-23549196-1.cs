    public class LocalizedText
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public CultureInfo Language { get; set; }
         
        public string TwoLetterISOLanguageName
        {
          get { return Language == null ? null : Language.TwoLetterISOLanguageName; }
          set { Language = CultureInfo.GetCultureInfo(value); }
        }
    }
