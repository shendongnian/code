    public enum AnimalCapability
    {
        Run,
        Fly,
        Devour
    }
    
    public abstract class Animal
    {
        public virtual string Name { get { return "Undefined"; } }
        protected IEnumerable<AnimalCapability> Capabilities;
        public bool HasCapability(AnimalCapability capability)
        {
            if (this.Capabilities != null)
                return this.Capabilities.ToList().Contains(capability);
            return false;
        }
    }
    
    public class Jaguar : Animal
    {
        public override string Name { get { return "Jaguar"; } }
        public Jaguar()
        {
            this.Capabilities = new AnimalCapability[] { AnimalCapability.Run, AnimalCapability.Devour };
        }
    }
    
    public class Owl : Animal
    {
        public override string Name { get { return "Owl"; } }
        public Owl()
        {
            this.Capabilities = new AnimalCapability[] { AnimalCapability.Fly };
        }
    }
