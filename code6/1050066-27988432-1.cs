    /// <summary>
    /// Extension method that helps to write the contents of a generic Dictionary to a string, ordered by it's values and 
    /// printing the key and it's value between brackets.
    /// </summary>
    /// <typeparam name="TKey">Generic key</typeparam>
    /// <typeparam name="TValue">Generic value type</typeparam>
    /// <param name="dictionary">The dictionary</param>
    /// <exception cref="ArgumentNullException">Throws an argument null exception if the provided dictionary is null</exception>
    /// <returns></returns>
    public static string PrintFrequencies<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if (dictionary == null)
            throw new ArgumentNullException("dictionary");
        var items = from kvp in dictionary
                    orderby kvp.Value
                    select kvp.Key + " [" + kvp.Value + "]";
        return string.Join(Environment.NewLine, items);
    }
