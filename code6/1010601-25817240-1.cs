    public class Item
    {
        [Key]
        public int Index { get; set; }
        public string Name { get; set; }
        public ICollection<ItemType> Types { get; set; }
        public ICollection<Def> Definitions { get; set; }
        public ICollection<Syn> Syns { get; set; }
        public ICollection<Generator> GeneratorList { get; set; }
        public ICollection<Point> RelatedItems { get; set; }
    }
