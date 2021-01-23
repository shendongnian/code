    public class Message
    {
        public string Name;
        public string EmailAddress;
        public string Text;
    
        public Message(string name, string emailAddress, string text)
        {
            this.Name = name;
            this.EmailAddress = emailAddress;
            this.Text = text;        
        }
    }
    
    public class Emailer
    {
        public void Send(Message message)
        {
            // Send email using Message Properties
        }
    }
