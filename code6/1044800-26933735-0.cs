    // conceptually, something like this (note that it's not checking if there are
    // enough values in the replacementValues array)
    static string ReplaceMultiple(
          string input, string placeholder, IEnumerable<string> replacementValues)
    {
        var enumerator = replacementValues.GetEnumerator();
        return Regex.Replace(input, placeholder, 
            m => { enumerator.MoveNext(); return enumerator.Current; });
    }
