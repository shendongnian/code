    public class WebHttpBehavior : IEndpointBehavior, IWmiInstanceProvider
    {
        internal const string GET = "GET";
        internal const string POST = "POST";
        internal const string WildcardAction = "*";
        internal const string WildcardMethod = "*";
