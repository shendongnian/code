    An example when using a regular expression to check if the input it numeric:
        string numericPattern = "^[0-9]+$";
	    string input = "1zd23";
	    bool result1 = Regex.IsMatch(value, numericPattern); //false
	    string input = "456";
	    bool result2 = Regex.IsMatch(value, numericPattern); //true
    And in a method:
        public bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, "^[0-9]+$");
        }
        //Usage:
        bool result = IsNumeric("qsd4156"); //false
