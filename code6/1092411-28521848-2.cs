        public static List<T> GetObjectList2<T, U>(List<U> givenObjects) where T : class
        {
            var result = new List<T>();
            if (typeof(T) == typeof(string))
            {
                foreach (var givenObject in givenObjects)
                {
                    var instance = givenObject.ToString();  // Your custom conversion to string.
                    result.Add((T)(object)instance);
                }
            }
            else
            {
                // Proceed as before
            }
            return result;
        }
