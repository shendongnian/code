    [DataContract, KnownType("GetSubclasses")]
    public abstract class Tree<TValue> where TValue : Value<TValue> {
        //Register sub-types statically with their generic parameter which is instantiated.
        protected static readonly List<Type> RegisteredTypes = new List<Type>();
        public static IEnumerable<Type> GetSubclasses() {      //This is new
            return RegisteredTypes;
        }
        static TreeElement() { // #1
            RegisteredTypes.Add(typeof(TValue));
        }
       
        [DataMember]
        public string Name;
        protected Tree() {}
    }
    
    [DataContract]
    public class ConcTree<TValue> : Tree<TValue> where TValue : Value<TValue> { 
        [DataMember]
        public TValue Value;
        public ConcTree(string n, TValue reg) {
            Name = n;
            Value = reg;
        }
        static ConcTree() {  //This is new
            ValueTypes.Add(typeof(ConcTree<TValue>)); 
        }
    }
    
    var result = new ConcTree<StringValue>("test", new StringValue() { S = "s_value" });
    var serializer = new DataContractJsonSerializer(typeof (Tree<StringValue>));
    using (var stream = new MemoryStream()) {
        serializer.WriteObject(stream, result); // No exception anymore.
        stream.Position = 0;
        using (var reader = new StreamReader(stream))
            return reader.ReadToEnd();
    }
