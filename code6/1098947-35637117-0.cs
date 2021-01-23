    public class MinWithStatusAttribute : ParameterBindingAttribute 
    {
        private readonly int _minValue;
        public MinWithStatusAttribute(int minValue)
        {
            _minValue = minValue;
        }
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter) => new MinWithStatusParameterBinding(parameter, _minValue);
    }
    public class MinWithStatusParameterBinding : HttpParameterBinding, IValueProviderParameterBinding
    {
        private readonly int _minValue;
        public HttpParameterBinding DefaultUriBinding; 
        public MinWithStatusParameterBinding(HttpParameterDescriptor desc, int minValue)
            : base(desc)
        {
            _minValue = minValue;
            var defaultUrl = new FromUriAttribute();
            this.DefaultUriBinding = defaultUrl.GetBinding(desc);
            this.ValueProviderFactories = defaultUrl.GetValueProviderFactories(desc.Configuration);
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return DefaultUriBinding.ExecuteBindingAsync(metadataProvider, actionContext, cancellationToken).ContinueWith((tsk) =>
            {
                var currentBoundValue = this.GetValue(actionContext);
                if (!(currentBoundValue is int)) return; //if it is not an Int, return.
                var currentBoundInt = (int)currentBoundValue;
                if (currentBoundInt >= _minValue) return; //If the value provided is greater than or equal to the min value, return. Else throw an error
                var preconditionFailedResponse = actionContext.Request.CreateResponse(HttpStatusCode.PreconditionFailed, $"The parameter {DefaultUriBinding.Descriptor.ParameterName} must be greater than or equal to {_minValue}" });
                throw new HttpResponseException(preconditionFailedResponse);
            }, cancellationToken);
        }
        public IEnumerable<ValueProviderFactory> ValueProviderFactories { get; } //IValueProviderParameterBinding
    }
