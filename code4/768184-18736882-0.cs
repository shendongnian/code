    public class Company : Entity  
    {    
        private Language l;
        public Company()
        {
            l = new Language();  
        }
        public string LanguageCode
        {  
         get
            {
                string language = l.Name;
                return language;
            }
        }
    }
