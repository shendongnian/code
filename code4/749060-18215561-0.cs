    public class MyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string Type { get; set; }
    }
