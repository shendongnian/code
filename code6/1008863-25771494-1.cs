    public static Dictionary<string, string> GetInputKeyValuePairs(string input)
    {
        var inputKeysAndValues = new Dictionary<string, string>();
        if (string.IsNullOrEmpty(input)) return inputKeysAndValues;
        const char keyValueDelimiter = '=';
        const char itemDelimeter = ',';
        const char valueContainer = '"';
        var currentKey = string.Empty;
        var currentValue = string.Empty;
        var processingKey = true;
        var processingValue = false;
    
        foreach (var character in input)
        {
            if (processingKey)
            {
                // Add characters to currentKey until we get to the delimiter
                if (character == keyValueDelimiter) processingKey = false;
                else currentKey += character;
                continue;
            }
            if (processingValue)
            {
                // Add characters to the currentValue until we get to the delimeter
                if (character == valueContainer) processingValue = false;
                else currentValue += character;
                continue;
            }
            if (character == itemDelimeter)
            {
                // We're between items now, so store the current Key/Value, reset
                // them to empty strings, and set the flag to start processing a key.
                inputKeysAndValues[currentKey] = currentValue;
                currentKey = currentValue = string.Empty;
                processingKey = true;
                continue;
            }
    
            // If we've come this far, then it means we're at the first quote before
            // a value, so ignore it and set the flag to start processing a value
            processingValue = true;
        }
    
        // Add the last key/value
        if (currentKey != string.Empty) inputKeysAndValues[currentKey] = currentValue;
        return inputKeysAndValues;
    }
