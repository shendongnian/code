    public class CreateDogModel 
    {
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public int Human { get; set; }
        public IEnumerable<Human> Humans { get; set; }
    }
