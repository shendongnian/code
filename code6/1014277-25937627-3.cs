    public interface IRequestInformation
    {
        string UserHostAddress { get; }
    }
    public class RequestInformation : IRequestInformation
    {
        public string UserHostAddress
        {
            get { return HttpContext.Current.Request.UserHostAddress; }
        }
    }
