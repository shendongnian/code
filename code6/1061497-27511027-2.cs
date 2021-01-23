    [DataContract, KnownType("GetKnownSubclassesOfRegion")]
    public abstract class Value<T> where T : Value<T> {
        //Register sub-types statically.
        protected static readonly List<Type> ValueTypes= new List<Type>();
        public static IEnumerable<Type> GetKnownSubclassesOfRegion() {
           return RegionTypes;
       }
    }
    [DataContract]
    public class StringValue : Value<StringValue> {
        [DataMember]
        public string S { get; set; }
        static StringValue() {
            ValueTypes.Add(typeof(StringValue ));
        }
    }
