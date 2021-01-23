    public class QueryFilterParameterBinding : HttpParameterBinding
    {
        private readonly HttpParameterBinding _modelBinding;
        //private readonly HttpParameterBinding _formatterBinding;
    
        public QueryFilterParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
        {
            _modelBinding = new ModelBinderAttribute().GetBinding(descriptor);
            //_formatterBinding = new FromBodyAttribute().GetBinding(descriptor);
        }
    
        public override async Task ExecuteBindingAsync(
            ModelMetadataProvider metadataProvider, 
            HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            await _modelBinding.ExecuteBindingAsync(metadataProvider, actionContext, cancellationToken);
            var queryFilter = GetValue(actionContext) as QueryFilter;
            if (queryFilter == null)
            {
                queryFilter = new QueryFilter();
                SetValue(actionContext, queryFilter);
            }
        }
    }
