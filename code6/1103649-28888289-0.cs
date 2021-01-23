    // Constraints just to be vaguely reasonable.
    public static class Reinterpret<T> where T : struct, IComparable<T>
    {
        public T Cast(int value) { ... }
        public T Cast(uint value) { ... }
        public T Cast(float value) { ... }
        public T Cast(double value) { ... }
        // etc       
    }
