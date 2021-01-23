    public class Brand
    {
        public Brand(Enum Data)
        {
            Name = Data.ToString();
            Id = Convert.ToInt32(Data); 
        }
    
        public string Name { get; private set; }
        public int Id { get; private set; }
    }
