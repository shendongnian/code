    // TODO: Find a better name :)
    public class TypeBlueprint
    {
        public Type Type { get; set; }
        public List<object> Arguments { get; set; }
        
        public TypeBlueprint()
        {
            this.Arguments = new List<object>();
        }
        public TypeBlueprint(Type type, params object[] arguments)
        {
            this.Type = type;
            this.Arguments = arguments.ToList();
        }
    }
