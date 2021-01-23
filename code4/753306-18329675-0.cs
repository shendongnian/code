    static class StringEx
    {
        public static string OverwriteWith(this string str, string value, int index)
        {
            if (index + value.Length < str.Length)
            {
                // Replace substring
                return str.Remove(index) + value + str.Substring(index + value.Length);
            }
            else if (str.Length == index)
            {
                // Append
                return str + value;
            }
            else
            {
                // Remove ending part + append
                return str.Remove(index) + value;
            }
        }
    }
    // abchello worldopqrstuvwxyz
    string text = "abcdefghijklmnopqrstuvwxyz".OverwriteWith("hello world", 3);
    // abchello world
    string text2 = "abcd".OverwriteWith("hello world", 3);
    // abchello world
    string text3 = "abc".OverwriteWith("hello world", 3);
    // hello world
    string text4 = "abc".OverwriteWith("hello world", 0);
