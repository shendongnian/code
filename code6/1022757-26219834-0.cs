    public static class HashGenerator
    {
        private const int seed = 29;
        private const int factor = 31;
        /// <summary>
        /// Method to generate a hash code from multiple objects.
        /// This can be used when overriding GetHashCode by passing in an object's key fields
        /// </summary>
        public static int GetHashCodeFromMany(params object[] objects)
        {
            unchecked
            {
                int hashCode = seed;
                int length = objects.Length;
                for (int counter = 0; counter < length; counter++)
                {
                    object obj = objects[counter];
                    if (obj != null)
                    {
                        int objHashCode = obj.GetHashCode();
                        hashCode *= factor + objHashCode;
                    }
                }
                return hashCode;
            }
        }
    }
