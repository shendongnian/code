    public class Globals {
        private Globals _Instance;
        public Globals Instance {
            get {
                if (_Instance == null)
                    _Instance = new Globals();
                return _Instance;
            }
        }
        private Globals() {
        }
        public string SomeProperty { get; set; }
    }
