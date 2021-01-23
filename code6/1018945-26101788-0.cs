    public abstract class DescriptedCodeValue
    {
        protected DescriptedCodeValue(int id, string description)
        {
            Id = id;
            Description = description;
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public static implicit operator int(DescriptedCodeValue val)
        {
            return val.Id;
        }
        public static implicit operator string(DescriptedCodeValue val)
        {
            return val.Description;
        }
        public override string ToString()
        {
            return Description;
        }
    }
