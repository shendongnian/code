    public interface IPersistent
    {
        IPersistent Clone();
    }
    public class Animal : IPersistent
    {
        IPersistent IPersistent.Clone()
        {
            return Clone();
        }
        public Animal Clone() { return new Animal();}
    }
