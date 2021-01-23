    public class UserValidationAttribute : ActionFilterAttribute
    {
        [Inject]
        private IRepository repository { get; set; }
    
        public UserValidationAttribute()
        {
        }
    }
