    public class MyAmazingValidationClass : ValidationAttribute
    {
        protected override bool IsValid(object value)
        {
            DateTime date;
            bool parsed = DateTime.TryParse((string)value, out date);
            //or maybe : 
            bool parsed = DateTime.ParseExact((string)value),"dd/MM/yyyy")
            if(!parsed)
                return false;
            
            return true;
         }
    }
