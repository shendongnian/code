    public class Message
    {
        public string Name;
        public string EmailAddress;
        public string Text;
        public Emailer Email = new Emailer();
    
        public Message(string name, string emailAddress, string text, Emailer emailer)
        {
            this.Name = name;
            this.EmailAddress = emailAddress;
            this.Text = text;
            this.Email= emailer;        
        }
    }
