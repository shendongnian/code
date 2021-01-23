    public class MyVoidActionDescriptor : HttpActionDescriptor
    {
        private readonly HttpActionDescriptor _currentDescriptor;
        public MyVoidActionDescriptor(HttpActionDescriptor currentDescriptor)
        {
            if (currentDescriptor == null)
                throw new ArgumentNullException("currentDescriptor");
            this._currentDescriptor = currentDescriptor;
        }
        // this is what we're here for
        public override IActionResultConverter ResultConverter
        {
            get { return new MyVoidConverter(); }
        }
        // wrapper methods from now on
        public override Collection<HttpParameterDescriptor> GetParameters()
        {
            return this._currentDescriptor.GetParameters();
        }
        public override Task<object> ExecuteAsync(HttpControllerContext controllerContext, IDictionary<string, object> arguments, CancellationToken cancellationToken)
        {
            return this._currentDescriptor.ExecuteAsync(controllerContext, arguments, cancellationToken);
        }
        public override string ActionName
        {
            get { return this._currentDescriptor.ActionName; }
        }
        public override Type ReturnType
        {
            get { return this._currentDescriptor.ReturnType; }
        }
    }
