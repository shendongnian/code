    public class UniqueRecordValidationAttribute<C, E> : ValidationAttribute
    	where C : DataContext, new() where E : class
    {
    	string PropertyName { get; set; }
    	
        public UniqueRecordValidationAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    
        public override bool IsValid(object value)
        {
            DataContext dataContext = new C();
    		Table<E> table = dataContext.GetTable<E>();
    		
    		return table.Count(PropertyName + " = @0", value) == 0;
        }
    }
    
    [UniqueRecordValidation<AssetTrackingEntities, ATUser_Account>("User_Login", ErrorMessage = "User Login Already Exists.")] 
    public string User_Login { get; set; } 
