    public static class Requires {
        public static T IsNotNull<T>(T instance, string paramName) where T : class {
            // Use ReferenceEquals in case T overrides equals.
            if (object.ReferenceEquals(null, instance) {
                // Call a method that throws instead of throwing directly. This allows
                // this IsNotNull method to be inlined.
                ThrowArgumentNullException(paramName);
            }
            return instance;
        }
        private static void ThrowArgumentNullException(paramName) {
            throw new ArgumentNullException(paramName);
        }
    }
