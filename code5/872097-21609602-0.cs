    public class Component
    {
        public int Id { get; set; }
        public string CompName { get; set; }
        public byte[] CompBlob { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
    public class Part
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public byte[] PartBlob { get; set; }
    }
