    public class RegexFromDbValidatorAttribute : ValidationAttribute
    {
    	private readonly IRepository _db;
    
        //parameterless ctor that initializes _db
     
    	public override ValidationResult IsValid(object value, ValidationContext context)
    	{
    		string regexFromDb = _db.GetRegex();
    
    		Regex r = new Regex(regexFromDb);
    
    		if (value is string && r.IsMatch(value as string)){
    			return ValidationResult.Success;
    		}else{
    			return new ValidationResult(FormatMessage(context.DisplayName));
    		}
    	}
    }
