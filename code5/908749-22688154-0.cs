    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        private string _propertyName;
    
        public RequiredAttribute([CallerMemberName] string propertyName = null)
        {
            _propertyName = propertyName;
        }
    
        public string PropertyName
        {
            get { return _propertyName; }
        }
    
        private string GetErrorMessage()
        {
          //Provide your Error Message Here..           
        }
    
        public override string FormatErrorMessage(string name)
        {
            //note that the display name for the field is passed to the 'name' argument
            return string.Format(GetErrorMessage(), name);
        }
    }
