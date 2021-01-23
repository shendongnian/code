    internal static class Assertions {
        private const string DefaultMessage = "Assertion failed";
        public static void Assert(bool condition, string message = null) {
            message = message ?? DefaultMessage;
            if (!condition) { throw new System.Exception(message); }
        }
    
        public static void NotNull(object o, string message = null) {
            message = message ?? DefaultMessage;
            Assert(!Object.ReferenceEquals(o, null), message);
        }
    
        public static void EtCaetera(..., string message = null) {
            message = message ?? DefaultMessage;
            Assert(..., message);
        }
    }
