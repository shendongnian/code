        public static List<T> GetObjectList<T, U>(List<U> givenObjects)
        {
            var result = new List<T>();
            if (typeof(T) == typeof(string))
            {
                foreach (var givenObject in givenObjects)
                    result.Add((T)(object)givenObject.ToString());
            }
            else
            {
                // Proceed as before
            }
        }
