    private string _address = string.empty
    
    public string Address { 
            get 
            {
                return this.Address;
            } 
            private set
            {
                string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4}))"
                                    + "|"
                                    + @"(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
    
                if (Regex.IsMatch(value, emailPattern))
                {
                    _address = value;
                }
                else
                {
                    throw new Exception(value + " doesn't seem to be a valid email address.");
                }
            }
