     public class CustomException
     {
        private string _message;
        private string _title;
    
        public CustomException()
        {
          _title = "";
          _message = "";
        }
    
        public CustomException(string title, string message)
        {
          _title = title;
          _message = message;
        }
     }
