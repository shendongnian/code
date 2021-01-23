     public class MailModels
    {
        public string From { get; set; }
        public string ToMain { get; set; }
        public string ToCC { get; set; }
        public string ToBCC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<MailGetter> SendToList { get; set; }
        public List<MailGetter> SendToCCList { get; set; }
        public List<MailGetter> SendToBCCList { get; set; }
    
        public MailModels()
        {
           this.SendToList  = new List<MailGetter>();
           this.SendToCCList = new new List<MailGetter>();
           this.SendToBCCList = new new List<MailGetter>();
        } 
    }
