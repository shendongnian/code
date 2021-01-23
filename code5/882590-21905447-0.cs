    string DoReplace(string input)
    {
        bool isInner = false;//flag to detect if we are in the inner string or not
        string result = "";//result to return
    
        foreach(char c in input)//loop each character in the input string
        {
            if(isInner && c == ',')//if we are in an inner string and it is a comma, append space
                result += " ";
            else//otherwise append the character
                result += c;
            
            if(c == '"')//if we have hit an inner quote, toggle the flag
                isInner = !isInner;
        }
    
        return result;
    }
