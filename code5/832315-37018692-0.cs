    public class CustomCompareAttribute : CompareAttribute
    {
        public CustomCompareAttribute(string otherProperty, string ErrorCode) : base(otherProperty)
        {
            ErrorMessage = CustomMessage(ErrorCode);
        }
        private static string CustomMessage(string ErrorCode) 
        {
            string ErrorMsg = ErrorCode;
            //ErrorMsg = Translate.Item(ErrorCode);  <-- My logic from database
            return ErrorMsg;
        }
    }
