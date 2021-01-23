    public void setFirstName(string newFirstName)
    {
        bool valid;
        valid = System.Text.RegularExpressions.Regex.IsMatch(newFirstName, "^[- a-zA-Z]*$");
        if (valid)
        {
            firstName = newFirstName;
        }
        else
        {
            firstName = " ";
        }
    }
