    public class MyClass {
        // A field
        public int Fast1;
        // An automatic property backed by a field
        public int Fast2 { get; set; }
        // A property backed by a field
        public int Fast3 {
            get { return Fast1; }
        }
        // Each time you call this property, some calculation is done
        public int LittleSlow1 {
            get {
                int j = 0;
                for (int i = 0; i < 1000000; i++) {
                    if (i > j) {
                        i = j;
                    }
                }
                return j;
            }
        }
        // This property is backed by a collection. There is a
        // scan of the collection to retrieve the value.
        public int LittleSlow2 {
            get {
                return ignoreme["LittleSlow1"];
            }
        }
        public Dictionary<string, int> ignoreme = new Dictionary<string, int>();
    }
