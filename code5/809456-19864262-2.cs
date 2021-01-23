    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        virtual public ICollection<Image> Images { get; set; }
    }
