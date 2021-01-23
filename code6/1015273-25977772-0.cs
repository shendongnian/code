    public class MyEvent
    {
        public int ClientId { get; set; }
        
        public override string ToString()
        {
            return ClientId.ToString();
        }
    }
