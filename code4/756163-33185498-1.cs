    public class MyAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        private Func<HttpRequestMessage, MyDependencyType> _dependencyFactory;
        public MyAuthenticationFilter() :
            this(request => (MyDependencyType)request.GetDependencyScope().GetService(typeof(MyDependencyType)))
        {
        }
        public MyAuthenticationFilter(Func<HttpRequestMessage, MyDependencyType> dependencyFactory)
        {
            _dependencyFactory = dependencyFactory;
        }
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var dependencyScope = context.Request.GetDependencyScope();
            var dependency = dependencyFactory.Invoke(context.Request);
            //use your dependency here
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public bool AllowMultiple { get; private set; }
    }
