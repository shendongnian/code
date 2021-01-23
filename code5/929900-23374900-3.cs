    public class UniqueRecordValidator<C, E> : IValidationAttribute
    	where C : DataContext, new() where E : class
    {
    	string PropertyName { get; set; }
    	
        public UniqueRecordValidator(string propertyName)
        {
            PropertyName = propertyName;
        }
    
        public bool IsValid(object value)
        {
            DataContext dataContext = new C();
    		Table<E> table = dataContext.GetTable<E>();
    		
    		return table.Count(PropertyName + " = @0", value) == 0;
        }
    }
    
    [UniqueRecordValidation(
        typeof(UniqueRecordValidator<AssetTrackingEntities, ATUser_Account>)
        "User_Login")] 
    public string User_Login { get; set; } 
