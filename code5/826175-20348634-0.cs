    public class EmailThingy
    {
        private readonly string userEmail;
        public EmailThingy(string userEmail)
        {
            if (userEmail == null)
                throw new ArgumentNullException("userEmail");
            this.userEmail = userEmail;
        }
        // other members go here...
    }
