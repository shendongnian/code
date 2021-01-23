    // The base interface for all items.
    public interface INamedItem
    {
        string Name { get; set; }
    }
    // all classes are derived from INamedItem, so you can always have the Name property.
    public interface IEatable : INamedItem
    {
        int AmountHealed { get; set; }
    }
    public class Healers : Ieatable
    {
        public string Name { get; set; }
        public int AmountHealed { get; set; }
        public Healers(int amountHealed, string name)
        {
            AmountHealed = amountHealed;
            Name = name;
        }
    }
