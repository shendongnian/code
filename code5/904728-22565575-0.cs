    public interface IAnimal
    {
    }
    
    public Interface ITiger : IAnimal
    {
        int NumberOfStripes { get; set; }
    }
    
    public class Animal : IAnimal
    {
    }
    
    public class Tiger : Animal, ITiger
    {
        public int NumberOfStripes { get; set; }
    }
