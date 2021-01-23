    string str = "AB123213CDF";
    if (!string.IsNullOrEmpty(str) && // for empty string
        char.IsLetter(str[0]) && //Starts with character
        str.Count(char.IsLetter) >= 6)   //Contains atleast 6 letters
    {
        //valid
    }
    else
    {
       //invalid
    }
