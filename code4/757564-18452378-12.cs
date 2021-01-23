    public class CustomUser : User
    {
        public Dictionary<string, object> Custom { get; set; }
        public CustomUser() : base()
        {
            Custom = new Dictionary<string, object>();
        }
    }
