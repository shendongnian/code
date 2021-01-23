    public class TableABC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual List<Colour> Colours { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
    public class Colour
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
