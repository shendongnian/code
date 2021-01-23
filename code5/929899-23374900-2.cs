    public class UniqueRecordValidationAttribute : ValidationAttribute
    {
    	public IValidationAttribute DynamicInstance { get; private set; }
     
        public UniqueRecordValidationAttribute(Type type, 
            params object[] arguments )
        {
            DynamicInstance = 
                Activator.CreateInstance(type, arguments) as IValidationAttribute;
        }
    	
        public override bool IsValid(object value)
        {
    		return DynamicInstance.IsValid(value);
        }
    }
    
    public class UniqueRecordValidator<C, E, P> : IValidationAttribute
        where C : DataContext, new() where E : class
    {
        Func<E, P, bool> Check { get; set; }
    
        public UniqueRecordValidator(Func<E, P, bool> check)
        {
            Check = check;
        }
    
        public bool IsValid(object value)
        {
            DataContext dataContext = new C();
            Table<E> table = dataContext.GetTable<E>();
    
            return table.Count(i => Check(i as E, (P)value)) == 0;
        }
    }
    
    public interface IValidationAttribute
    {
    	bool IsValid(object value);
    }
