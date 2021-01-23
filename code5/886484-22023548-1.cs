	void Main() {
		var conventions = new ConventionPack();
		var representAsDouble = new RepresentationSerializationOptions(BsonType.Double);
		var representArrayAsDouble = new ArraySerializationOptions(representAsDouble);
		var representDictionaryAsDouble = new DictionarySerializationOptions(){ KeyValuePairSerializationOptions = new KeyValuePairSerializationOptions() { ValueSerializationOptions = representArrayAsDouble}};
		conventions.Add(new MemberSerializationOptionsConvention(typeof(decimal), representAsDouble));
		conventions.Add(new MemberSerializationOptionsConvention(typeof(decimal[]), representArrayAsDouble));
		conventions.Add(new MemberSerializationOptionsConvention(typeof(Dictionary<string, decimal[]>), representDictionaryAsDouble));
		conventions.Add(new MemberSerializationOptionsConvention(typeof(SortedDictionary<string, decimal[]>), representDictionaryAsDouble));
		conventions.Add(new MemberSerializationOptionsConvention(typeof(Test.DerivedDictionary), representDictionaryAsDouble));
		ConventionRegistry.Register("Serialize decimal as double", conventions, t => true);
		Console.WriteLine(new Test().ToJson(new JsonWriterSettings() { Indent = true }));
	}
	class Test : DbObject {
		public Test() {
			Array = new decimal[2];
			Array[0] = 2;
			Array[1] = 3;
			Dict = new Dictionary<string, decimal[]>();
			Dict["test"] = Array;
			Dict2 = new SortedDictionary<string, decimal []>();
			Dict2["test"] = Array;
			Dict3 = new DerivedDictionary();
			Dict3["test"] = Array;
			Dict4 = new Dictionary<string, DerivedDictionary>();
			Dict4["test"] = Dict3;
		}
		public decimal Field = 1;
		public decimal [] Array;
		public Dictionary<string, decimal[]> Dict;
		public SortedDictionary<string, decimal[]> Dict2;
		public DerivedDictionary Dict3;
		public Dictionary<string, DerivedDictionary> Dict4;
		public class DerivedDictionary : Dictionary<string, decimal[]> {
		}
	}
