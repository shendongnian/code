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
            public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                HttpActionContext actionContext, CancellationToken cancellationToken)
            {
                IEdmModel model = actionContext.Request.GetEdmModel() ?? actionContext.ActionDescriptor.GetEdmModel(typeof(Organization));
                ODataQueryContext context = new ODataQueryContext(model, typeof(Organization));
                ODataQueryOptions<Organization> query = new ODataQueryOptions<Organization>(context, actionContext.Request);
                FindOrganizationsQuery findQuery = new FindOrganizationsQuery(query);
                SetValue(actionContext, findQuery);
                return Task.FromResult(0);
            }
        }
    }
