    public class MyClass {
        public int confirmed { get; private set; }
    
        public MyClass() {
            this.confirmed = "This"; // This is fine as we have private access
        }
    }
