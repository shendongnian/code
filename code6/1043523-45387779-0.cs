    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ValidatePropertiesAttribute:ValidationAttribute
    {
         private Type TargetClass;
         public ValidatePropertiesAttribute(Type targetClass)
         {
             TargetClass = targetClass;
             if(Validate() == false)
             {
                 throw new Exception("It's not valid!! add more properties to the type 'x'.");
             }
         }
         public bool Validate()
         {
             //Use Target Class, 
             //if you need extract properties use TargetClass.GetProperties()...
             //if you need create instance use Activator..
         }         
    }
