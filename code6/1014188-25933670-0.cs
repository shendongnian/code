    //use System.Text.RegularExpressions before using this function
    public bool vldRegex(string strInput)
    {
    //create Regular Expression Match pattern object
    Regex myRegex = new Regex("^[a-fA-F0-9]+$");
    //boolean variable to hold the status
    bool isValid = false;
    if (string.IsNullOrEmpty(strInput))
    {
       isValid = false;
    }
    else
    {
       isValid = myRegex.IsMatch(strInput);
    }
    //return the results
    return isValid;
    }
