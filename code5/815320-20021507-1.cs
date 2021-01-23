    public abstract class BaseClass
    {
        //All your properties
        public virtual Boolean Validate()
        {
            //Common Validation code
        }
    }
    
    public class A : BaseClass
    {
        public override Boolean Validate()
        {
             return AValidation || base.Validate();
        }
    }
    //Same for B
