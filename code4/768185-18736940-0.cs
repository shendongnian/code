    public class Company : Entity
    {
        public string LanguageName{ get;set; }
        public Language GetLanguage()
        {
            Language language = new Language(){ Name = this.LanguageName };
            return language;
        }
    }
