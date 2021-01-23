    public class EmailFields
    {
        public string Root {get;set;}
        public string Action {get;set;}
        public string TemplateName {get;set;}
        public DateTime Date {get;set;}
        public EmailHelper
        {
            Date = DateTime.Now;
        }
    }
