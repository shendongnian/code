    public class Container {
        public List<Base> items;
        public string Save() {
            return JsonConvert.SerializeObject(items, new PolymorphicJsonConverter())
        }
        public void Load(string jsonText) {
            items = JsonConvert.DeserializeObject<List<Base>>(jsonText, new PolymorphicJsonConverter());
        }
    }
