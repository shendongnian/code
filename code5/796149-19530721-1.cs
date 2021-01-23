    public bool IsValidPassword(string input) {
        // First just check for a digit
        if(!RegEx.IsMatch(input, "\d")) return false;
        // Then check for special character
        if(!RegEx.IsMatch(input, "[@#$%&*+_()':;?.,!\[\]\\\-]")) return false;
        // Require a letter?
        if(!RegEx.IsMatch(input, "[a-zA-Z]")) return false;
        // Length requirement?
        if(input.Length < 8) return false;
        return true;
    } 
