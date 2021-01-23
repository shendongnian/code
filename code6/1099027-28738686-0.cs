    public interface IHasPropertyA
    {
        string PropertyA { get; set; }
    }
    public interface IHasPropertyB
    {
        string PropertyB { get; set; }
    }
    
    public class ClassA : IHasPropertyA, IHasPropertyB
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
    }
