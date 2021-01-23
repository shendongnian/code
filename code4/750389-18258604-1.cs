    public static class HttpActionDescriptorExtensions
    {
        internal const string EdmModelKey = "MS_EdmModel";
        internal static IEdmModel GetEdmModel(this HttpActionDescriptor actionDescriptor, Type entityClrType)
        {
            // save the EdmModel to the action descriptor
            return actionDescriptor.Properties.GetOrAdd(EdmModelKey + entityClrType.FullName, _ =>
            {
                ODataConventionModelBuilder builder = new ODataConventionModelBuilder(actionDescriptor.Configuration, isQueryCompositionMode: true);
                EntityTypeConfiguration entityTypeConfiguration = builder.AddEntity(entityClrType);
                builder.AddEntitySet(entityClrType.Name, entityTypeConfiguration);
                IEdmModel edmModel = builder.GetEdmModel();
                return edmModel;
            }) as IEdmModel;
        }
    }
