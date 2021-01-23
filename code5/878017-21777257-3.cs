    using System.Collections.Generic;  // for List<T>
    using System.Linq;                 // for ILookup<TKey, TValue> and .ToLookup(…)
    // This represents the source of your strings. It doesn't have to be sorted:
    var strings = new List<string>() { "Foo", "Bar", "Baz", "Quux", … };
    // This is how you would build a 1:n lookup table mapping from first characters
    // to all strings starting with that character. Empty strings are excluded:
    ILookup<char, string> stringsByFirstCharacter =
        strings.Where(str => !string.IsNullOrEmpty(str))  // exclude empty strings
               .ToLookup(str => str[0]);                  // key := first character
    // This is how you would look up all strings starting with B.
    // The output will be Bar and Baz:
    foreach (string str in stringsByFirstCharacter['B'])
    {
        Console.WriteLine(str);
    }
