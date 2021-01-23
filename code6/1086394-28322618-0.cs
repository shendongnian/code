      public class JOVALException: Exception {
        ...
        // Note Exception "innerException" argument
        public JOVALException(ErrorCodes _errCode, Exception innerException, String _message = "")
          : base(_message, inner) {
          ...
        }
      }
