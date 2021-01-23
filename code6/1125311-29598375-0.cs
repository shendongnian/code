    [Flags]
    public enum NameValidation
    {
        PassedValidation = 0,
        ContainNumbers = 1,
        ContainIllegalCharacters = 2,
        ContainEmptyString = 4,
    }
    
    public class DataMember 
    {
        public NameValidation FirstNameState {get; set;}
        public NameValidation LastNameState {get; set;}
    	
        public DataMember(string lastName, string firstName)
        {
            FirstNameState = ValidateName(firstName);
    		LastNameState = ValidateName(lastName);
        }
    	
    	private NameValidation ValidateName(string name)
    	{
    		var validation = NameValidation.PassedValidation;
    		if(string.IsNullOrEmpty(name)) validation |= NameValidation.ContainEmptyString;
    		//Validate illegal characters
    		//Validate numbers
    		return validation;
    	}
    }
