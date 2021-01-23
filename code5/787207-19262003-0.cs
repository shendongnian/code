    internal bool IsInputLike(string input)
        {
        //Check to see if the input statement exists in any of the 4 fields
        bool check = (Code.ToLower().Contains(input.Trim().ToLower()) 
            || Name.ToLower().Contains(input.Trim().ToLower()) 
            || ClientCode.ToLower().Contains(input.Trim().ToLower()) 
            || ClientName.ToLower().Contains(input.Trim().ToLower()));
        return check;
        }
