    IDictionary inputAsDictionary = input as IDictionary;
    if (inputAsDictionary != null)
    {
        // Valid :  input is a dictionary.
        ICollection dictKeys = inputAsDictionary.Keys; // This is a list of all keys
        ICollection dictValues = inputAsDictionary.Values; // This is a list of all values
    
        // Iterate over all keys
        for(var dictKey in dictKeys)
        {
            Console.WriteLine(dictKey); // Print the key
            Type dictKeyType = dictKey.GetType(); // Get the type of key if required
            // ...
        }
    
        // Similarly, iterate over all values
        for(var dictValue in dictValues)
        {
            Console.WriteLine(dictValue); // Print the value
            Type dictValueType = dictValue.GetType(); // Get the type of value if required
            // ...
        }
    }
