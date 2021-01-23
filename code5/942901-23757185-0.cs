    static public bool IsOnlyNumeric(string InputText)
    {
        //Returns true if only numeric
        bool val = System.Text.RegularExpressions.Regex.IsMatch(InputText, "^[1-9]\d*$");
    
        return val;
    
    }  
