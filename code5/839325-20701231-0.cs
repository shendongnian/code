    internal static class Assertions {
        public static void Assert(bool condition, string message = null) {
            if (!condition) {
                throw new System.Exception(message ?? "Assertion failed");
            }
        }
    }
    internal static class Wrapper {
        public static void Assert(bool condition, string message = null) {
            Assertions.Assert(condition, message);
        }
    }
