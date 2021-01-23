    using System.Collections.Generic;  // for List<T>
    using System.Linq;                 // for ILookup<TKey, TValue>
    // this represents the source of your strings:    
    var strings = new List<string>() { "Foo", "Bar", "Baz", "Quux", … };
    // this is how you would build a 1:n lookup table mapping from first characters
    // to all strings starting with that character: (empty strings are excluded)
    ILookup<char, string> stringsIndexedByFirstCharacter =
        strings.Where(str => string.IsNullOrEmpty(str))
               .ToLookup(str => str[0]);
