    public class CustomViewModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ICustomTypeDescriptor GetTypeDescriptor(Type type) {
            if (type.Equals(typeof(Entity)) {
                return new CustomEntityDescriptor();  // I guess you could use a singleton as well
            }
            return base.GetTypeDescriptor(type);
        }
    }
