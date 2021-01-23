        public abstract class BaseNode
    {
        [JsonConstructor] // ctor used when Json Deserializing
        protected BaseNode(string Owner, string Name, string Identifier)
        {
            this.Name = Name;
            this.Identifier = Identifier;
        }
        // ctor called by concrete class.
        protected BaseNode(string [] specifications)
        {
            if (specifications == null)
            {
                throw new ArgumentNullException();
            }
            if (specifications.Length == 0)
            {
                throw new ArgumentException();
            }
            Name = specifications[0];
            Identifier = specifications[1];
            
        }
        public string Name{ get; protected set; }
        public string Identifier { get; protected set; }
        
    }
   
    public class ComputerNode: BaseNode
    {
        public string Owner { get; private set; }
        [JsonConstructor] // not visible while creating object from outside and only used during Json Deserialization.
        private ComputerNode(string Owner, string Name, string Identifier):base(Owner, Name, Identifier)
        {
            this.Owner = Owner;
        }
        public ComputerNode(string[] specifications):base(specifications)
        {
            Owner = specifications[2];
        }
    }
