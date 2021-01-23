    public static class SerializationExtensions
    {
        public static string Serialize<T>(this T obj, IEnumerable<Type> knownTypes)
        {
            var serializer = new DataContractSerializer(obj.GetType(), knownTypes);
            using (var writer = new StringWriter())
            using (var stm = new XmlTextWriter(writer))
            {
                serializer.WriteObject(stm, obj);
                return writer.ToString();
            }
        }
        public static T Deserialize<T>(this string serialized, IEnumerable<Type> knownTypes)
        {
            var serializer = new DataContractSerializer(typeof(T), knownTypes);
            using (var reader = new StringReader(serialized))
            using (var stm = new XmlTextReader(reader))
            {
                return (T)serializer.ReadObject(stm);
            }
        }
    }
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
    public class CodedAddress
    {
        public int CountryCode { get; set; }
        public int CityCode { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var personsWithKnownTypes = new Dictionary<string, Address>();
            personsWithKnownTypes.Add("John Smith", new Address { Country = "US", City = "New York" });
            personsWithKnownTypes.Add("Jean Martin", new Address { Country = "France", City = "Paris" });
            // no need to provide known types to the serializer
            var serializedPersons1 = personsWithKnownTypes.Serialize(null);
            var deserializedPersons1 = serializedPersons1.Deserialize<Dictionary<string, Address>>(null);
            var personsWithoutKnownTypes = new Dictionary<string, object>();
            personsWithoutKnownTypes.Add("John Smith", new Address { Country = "US", City = "New York" });
            personsWithoutKnownTypes.Add("Jean Martin", new CodedAddress { CountryCode = 33, CityCode = 75 });
            // must provide known types to the serializer
            var knownTypes = new List<Type> { typeof(Address), typeof(CodedAddress) };
            var serializedPersons2 = personsWithoutKnownTypes.Serialize(knownTypes);
            var deserializedPersons2 = serializedPersons2.Deserialize<Dictionary<string, object>>(knownTypes);
        }
    }
