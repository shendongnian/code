    IDictionary inputAsDictionary = input as IDictionary;
    if (inputAsDictionary != null)
    {
        // Valid :  input is a dictionary.
        ICollection dictKeys = inputAsDictionary.Keys;
        ICollection dictValues = inputAsDictionary.Values;
    
        for(var dictKey in dictKeys)
        {
            Type dictKeyType = dictKey.GetType();
            // Now you have the type of key. Carry on...
        }
    
        // Similarly for values...
        for(var dictValue in dictValues)
        {
            Type dictValueType = dictValue.GetType();
            // Now you have the type of value. Carry on...
        }
    }
