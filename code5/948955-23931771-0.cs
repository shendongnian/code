    public class Message
    {
        public Message()
        {
            Pages = new List<Page>();
        }
    
        public List<Page> Pages { get; private set; }
    
        public Message Add(Page page)
        {
           Pages.Add(page);
           return this;
        }
    }
