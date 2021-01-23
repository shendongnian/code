    public string GetVariable(string variable_name) {
        int startIndex = SCRIPT_CONTENT.IndexOf(variable_name);
        if (startIndex < 0) {
            return string.Empty; // or throw an exception
        }
        
        startIndex += variable_name.Length + 2;
        int endIndex = SCRIPT_CONTENT.IndexOf(";", startIndex);
        return SCRIPT_CONTENT.Substring(startIndex, endIndex - startIndex);
    }
