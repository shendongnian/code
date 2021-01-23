    public class ObjectA {
        public string Name { get; set; }
        public static string GetName(ObjectA instance) {
            return instance.Name;
        }
    }
