    internal bool IsInputLike(string input)
    {
        string input = input.Trim().ToLower();
        //Check to see if the input statement exists in any of the 4 fields
        bool check = (Code.ToLower().Contains(input) 
                || Name.ToLower().Contains(input) 
                || ClientCode.ToLower().Contains(input) 
                || ClientName.ToLower().Contains(input));
    
        return check;
    }
