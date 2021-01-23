    public class UniqueRecordValidationAttribute<C, E, P> : ValidationAttribute
    	where C : DataContext, new() where E : class
    {
    	Func<E, P, bool> Check { get; set; }
    	
        public UniqueRecordValidationAttribute(Func<E, P, bool> check)
        {
            Check = check;
        }
    
        public override bool IsValid(object value)
        {
            DataContext dataContext = new C();
    		Table<E> table = dataContext.GetTable<E>();
    		
    		return table.Count(i => Check(i as E, (P)value)) == 0;
        }
    }
