    public class ForcedObjectSerializer : JsonSerializer
    {
        public ForcedObjectSerializer()
            : base()
        {
            this.ContractResolver = new ForcedObjectResolver();
        }
    }
    
