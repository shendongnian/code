    public partial class MessageSource
    {
        public MessageSource()
        {
            this.messages = new HashSet<Message>();
        }
    
        public int id { get; set; }
        public string category { get; set; }
        public string message { get; set; }
        public string message_translation { get; set; }
    
        public virtual ICollection<Message> messages { get; set; }
        public string getTranslate()
        {
            if(message_translation == null)
            {
                Message msg = messages.FirstOrDefault(m => m.language.Equals(Translate.Instance.getLanguage()));
                if(msg != null)
                {
                    message_translation = msg.translation;
                }
                else
                {
                    message_translation = String.Empty;
                }
            }
            return message_translation;
        }
    }
