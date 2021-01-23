    public class MailModels
    {
        public MailModels()
        {
          this.SendToList = new List<MailGetter>();
        }
    
        ...
        public List<MailGetter> SendToList { get; private set; }
        ...
    }
