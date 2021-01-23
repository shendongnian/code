    public class NewService<T> : BaseService<T>
    {
        private readonly FooService<T> _fooService;
        private readonly AuditableService<T> _auditableService;
        public NewService (AuditableService<T> auditableService, FooService<T> fooService)
	    {
		    if(auditableService  == null)
			    throw new ArgumentNullException("auditableService ");
            
		    if(fooService == null)
			    throw new ArgumentNullException("fooService");
            _auditableService = auditableService;
            _fooService = fooService;
	    }
        public override Task<int> AddAsync(T t)
        {
 	         return _fooService.UpdateAsync(t);
        }
        public override Task<int> DeleteAsync(T t)
        {
 	         return _auditableService.DeleteAsync(t);
        }
    }
