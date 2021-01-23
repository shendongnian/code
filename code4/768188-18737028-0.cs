    public class Company : Entity  
    {   
        private Language languageCode;
        public Company
        {
            languegeCode = new Language();
        }
        public string LanguageCode
        {  
            get
            {
                return languageCode.Name;
            }
        }
    }
