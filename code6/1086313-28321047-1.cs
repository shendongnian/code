    public class Product
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return this.Description;
        }
    }
