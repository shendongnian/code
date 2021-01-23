    public class Company : Entity  
    {   
        private string _languageCode 
        public string LanguageCode
         {  
             get
             {
                if (String.IsNullOrEmpty(_languageCode) 
                {
                   Language l = new Language();              
                   _languageCode = l.Name;
                }
                return _languageCode
             }
         }
    }
