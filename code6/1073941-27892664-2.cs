    public class Base
    {
        [JsonProperty]
        private string Type { get { return "Base"; } }
    }
    public class Inherited : Base
    {
        [JsonProperty]
        [JsonPreferDerivedPropertyAttribute]
        private string Type { get { return "Inherited"; } }
    }
    public class VeryInherited : Inherited
    {
        [JsonProperty]
        public string VeryInheritedProperty { get { return "VeryInherited"; } }
    }
    public static class TestOverride
    {
        public static void Test()
        {
            var inherited = new Inherited();
            var json1 = JsonConvert.SerializeObject(inherited, Formatting.Indented, new JsonSerializerSettings() { ContractResolver = new PreferDerivedPropertyContractResolver() });
            var veryInherited = new VeryInherited();
            var json2 = JsonConvert.SerializeObject(veryInherited, Formatting.Indented, new JsonSerializerSettings() { ContractResolver = new PreferDerivedPropertyContractResolver() });
            Debug.WriteLine(json1);
            Debug.WriteLine(json2);
        }
    }
