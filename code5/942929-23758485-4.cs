    foreach (string s in lst)
    {
        if (s.StartsWith("[") && s.EndsWith("]"))
        {
            //add to OuterBracket_List
            OuterBracket_List.Add(s);
        }
        else
        {
            int n;
            if (int.TryParse(s, out n) == false && isAlphaNumeric(s))                   
            {     
	            //add AlphaNumeric_List
                AlphaNumeric_List.Add(s);
            } 
	        else
            {
                //add n to Numeric List if required
            }
        }
    }
	//method to check string is AlphaNumeric Note: Regex can be used
	public bool isAlphaNumeric(string strToCheck)
    {            
        for (int i = 0; i < strToCheck.Length; i++)
        {
            if (char.IsLetter(strToCheck[i]) == false)
            {
                return true;
            }
        }
        return false;
    }
    
