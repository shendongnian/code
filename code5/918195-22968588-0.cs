    public class AController : BaseController
    {
        protected override bool abstractValidation()
        {
           //code for A validation
        }
    }
    
    public class BController : BaseController
    {
        protected override bool abstractValidation()
        {
           //code for B validation
        }
    }
    
    public abstract class BaseController
    {
        protected abstract bool abstractValidation();
    
        protected bool validate()
        {
            //code for common validation
            
            //then, call the implementations validation method
            var isValid = abstractValidation();
    
            return isValid;
        }
    }
