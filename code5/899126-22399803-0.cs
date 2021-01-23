    public interface IAntiForgeryValidator
    {
        void Validate(string cookieToken, string formToken);
    }
    public class AntiForgeryValidator : IAntiForgeryValidator
    {
        public void Validate(string cookieToken, string formToken)
        {
            AntiForgery.Validate(cookieToken, formToken);
        }
    }
