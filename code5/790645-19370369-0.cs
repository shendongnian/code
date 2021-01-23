    public abstract class MyClass {
        protected MyClass(int i) {
            if (i < 0) {
                throw new ArgumentOutOfRangeException("i", "Must be >= 0");
            }
        }
        // ... other members ...
    }
