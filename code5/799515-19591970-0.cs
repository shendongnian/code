    void Main()
    {
        _CloneMapping[typeof(Dummy)] = (object obj) =>
        {
            Dummy d = (Dummy)obj;
            return new Dummy { Field = d.Field, Property = d.Property };
        };
    
        object original = new Dummy { Property = 42, Field = "Meaning of life" };
        object clone = Clone(original);
    
        ((IDummy)original).Mutate(); // will modify the boxed struct in-place
        original.Dump();
    
        // should output different if Clone did its job
        clone.Dump();
    }
    
    static readonly Dictionary<Type, Func<object, object>> _CloneMapping = new Dictionary<Type, Func<object, object>>();
    static object Clone(object input)
    {
        if (input == null)
            return null;
    
        var cloneable = input as ICloneable;
        if (cloneable != null)
            return cloneable.Clone();
    
        Func<object, object> cloner;
        if (_CloneMapping.TryGetValue(input.GetType(), out cloner))
            return cloner(input);
    
        throw new NotSupportedException();
    }
    
    public interface IDummy
    {
        void Mutate();
    }
    
    public struct Dummy : IDummy
    {
        public int Property { get; set; }
        public string Field;
    
        public void Mutate()
        {
            Property = 77;
            Field = "Mutated";
        }
    }
