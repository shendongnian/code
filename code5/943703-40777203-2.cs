    [AttributeUsage(AttributeTargets.Property)]
    public class Email : Attribute
    {
        static public void Validate(string value)
        {
            //if value is not a valid email, throw an exception!
        }
    }
    //Validation aspect handle all my vlidation custom attribute (here only email)
    public class Validation : Aspect
    {
        override protected Advice Advise(Type type, MethodInfo method)
        {
            foreach (var property in type.GetProperties())
            {
                if (property.GetSetMethod() == method)
                {
                    //only if email attribute is defined
                    if (Attribute.IsDefined(property, typeof(Email))
                    {
                        //email validation is only for string type property.
                        if (property.PropertyType != typeof(string)) { throw new NotSupportedException("email attribute can only be used on string type property"); }
                        
                        //inject email validation before setter.
                        return new Before((instance, arguments) => Email.Validate((string)arguments[0]));
                        //can be done by linq Expression alternative without boxing/unboxing
                        //return new Before(arguments=> Expression.Call(Metadata.Method(() => Email.Validate(Argument<string>.Value)), arguments.Last());
                        //argumrnts.Last() to handle static or instance property with same way because last arguments is always value of property.
                    }
                }
            }
            
            //no validation requiered.
            return null;
        }
    }
