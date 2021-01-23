    public class TestClass {
        private int[] ids = new int[] { 1, 2, 3, 4, 5 };
        public string Name { get; set; }
        public string Description { get; set; }
        public int? this[int index] {
            get {
                if (index < 0 || index > ids.Length - 1)
                    return null;
                return ids[index];
            }
            set {
                if (value == null)
                    throw new ArgumentNullException(
                        "this[index]", 
                        "Ids are not nullable"
                    );
                ids[index] = (int)value;
            }
        }
    }
