    string specialCharacters = @"\~|!|\@|\#|\$|%|\^|\&|\*|_|\+|\||\{|\}|:\""|\<|\>|\?|\[|\]|;|'|/|=|\\|№";
    
    public bool ValidateCharacters(string pattern, AddressViewModel model)
    {
    	var reg = new Regex(pattern);
    	return reg.IsMatch(model.Index) == false && reg.IsMatch(model.Area) == false;
    }
