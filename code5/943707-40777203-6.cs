    [AttributeUsage(AttributeTargets.Property)]
    public class Email : Attribute
    {
        //validation method to use for email checking
        static public void Validate(string value)
        {
            //if value is not a valid email, throw an exception!
        }
    }
