    public class classA
    {
        public string ID { get; private set; }
        
        public classA(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                throw ArgumentException("id");
            }
            
            ID = id;
        }
    }
