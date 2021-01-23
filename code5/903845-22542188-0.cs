    /// <summary>
    /// Replaces each existing key within the original string by adding a number to it.
    /// </summary>
    /// <param name="original">The original string.</param>
    /// <param name="key">The key we are searching for.</param>
    /// <param name="offset">The offset of the number we want to start with. The default value is 0.</param>
    /// <param name="increment">The increment of the number.</param>
    /// <returns>A new string where each key has been extended with a number string with "offset" and beeing incremented with "increment".The default value is 1.</returns>
    /// <example>
    /// Assuming that we have an original string of "mapmapmapmap" and the key "map" we
    /// would get "map0map1map2map3" as result.
    /// </example>
    public static string AddNumberToKeyInString(string original, string key, int offset = 0, int increment = 1)
    {
        if (original.Contains(key))
        {
            int counter = offset;
            int position = 0;
            int index;
            // While we are withing the length of the string and
            // the "key" we are searching for exists at least once
            while (position < original.Length && (index = original.Substring(position).IndexOf(key)) != -1)
            {
                // Insert the counter after the "key"
                original = original.Insert(position + key.Length, counter.ToString());
                position += index + key.Length + counter.ToString().Length;
                counter += increment;
            }
         }
         return original;
    }
