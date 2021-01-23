    public abstract class SocialNetwork
    {
        public List<string> History { get; private set; }
 
        protected SocialNetwork()
        {
            History = new List<string>();
        }
 
        public void Post(string comment, byte[] image)
        {
            DoPost(comment, image);
            History.Add(comment);
        }
     
        protected virtual void DoPost(string comment, byte[] image)
        {
        }
    }
