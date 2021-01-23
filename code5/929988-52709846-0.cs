    public static bool ContainsTyped<T>(this JArray arr, T item)
    {
        return arr.Any(it =>
        {
            T typed;
            try
            {
                typed = it.ToObject<T>();
            }
            catch (JsonException e)
            {
                Console.WriteLine("Couldn't parse array item {0} as type {1}: {2}", it, typeof(T), e);
                return false;
            }
    
            return typed.Equals(item);
        });
    }
