    public class ErrorMessage
    {
        public ErrorMessage(string message)
        {
            Message = message;
        }
        public string Message { get; private set; }
    }
    public static class ContextHelper
    {
        public static void SetCustomError(this OAuthGrantResourceOwnerCredentialsContext context, string errorMessage)
        {
            var json = new ErrorMessage(errorMessage).ToJsonString();
            context.SetError(json);
            context.Response.Write(json);
        }
    }
