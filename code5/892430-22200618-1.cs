    public SomeModel : IValidatableObject
    {
    	private readonly IRepository _db;
    
        //don't forget to initialize _db in ctor
    
        public string Telephone {get; set;}
    
    	public IEnumerable<ValidationResult> Validate(ValidationContext context)
    	{
    
    		string regexFromDb = _db.GetRegex();
    
    		Regex r = new Regex(regexFromDb);
    
    		if (!r.IsMatch(Telephone))
    			yield return new ValidationResult("Invalid telephone number", new []{"Telephone"});
    	}
    }
