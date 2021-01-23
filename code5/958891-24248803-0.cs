    public class ServerSideOnlyRegularExpressionAttribute : RegularExpressionAttribute
    {
        public ServerSideOnlyRegularExpressionAttribute(string pattern)
            : base(pattern)
        {
        }
    }
