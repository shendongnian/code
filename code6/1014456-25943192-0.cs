    public interface IAnimal
    {
        UInt32 Height { get; }
    }
    public interface IExtension
    {
        IEnumerable<IAnimal> GetAnimals();
    }
