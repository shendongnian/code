    public class CustomQueryBindingAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new CustomQueryBinding(parameter);
        }
        internal class CustomQueryBinding : HttpParameterBinding
        {
            public CustomQueryBinding(HttpParameterDescriptor parameter)
                : base(parameter)
            {
            }
        internal class CustomQueryBinding : HttpParameterBinding
        {
            public CustomQueryBinding(HttpParameterDescriptor parameter)
                : base(parameter)
            {
            }
            public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                HttpActionContext actionContext, CancellationToken cancellationToken)
            {
                IEdmModel model = actionContext.Request.GetEdmModel() ?? actionContext.ActionDescriptor.GetEdmModel(typeof(Organization));
                ODataQueryContext queryContext = new ODataQueryContext(model, typeof(Organization));
                object customQuery = CreateCustomQuery(queryContext, actionContext.Request);
                SetValue(actionContext, customQuery);
                return Task.FromResult(0);
            }
            private object CreateCustomQuery(ODataQueryContext queryContext, HttpRequestMessage request)
            {
                Type parameterType = Descriptor.ParameterType;
                // Assuming all custom queries have this public property.
                Type oDataQueryOptionsOfTType = parameterType.GetProperty("ODataQuery").PropertyType;
                object odataQueryOptions = Activator.CreateInstance(oDataQueryOptionsOfTType, queryContext, request);
                return Activator.CreateInstance(parameterType, odataQueryOptions);
            }
        }
    }
