    public abstract class EnumBase<T> where T : EnumBase<T>
    {
        static Lazy<List<T>> values = new Lazy<List<T>>(FindEnumMembers);
        public static IEnumerable<T> Values
        {
            get
            {
                return values.Value;
            }
        }
    
        static List<T> FindEnumMembers()
        {
            Type derivedType = typeof(T);
            return derivedType.GetFields()
                              .Where(f => f.FieldType == derivedType)
                              .Select(f => (T)f.GetValue(null))
                              .ToList();
        }
    
        public string name { get; private set; }
    
        protected EnumBase(string name)
        {
            this.name = name;
        }
    
        public override string ToString()
        {
            return this.name;
        }
    }
    
    public class Day : EnumBase<Day>
    {
        public static readonly Day MONDAY = new Day("monday");
        public static readonly Day TUESDAY = new Day("tuesday");
        //...
    
        private Day (string name) : base (name) 
        {
    
        }
    }
