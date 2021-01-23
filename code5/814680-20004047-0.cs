    public class RequiredModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        ClientSettings _clientSettings;
        public RequiredModelMetadataProvider(ClientSettings clientSettings)
        {
            _clientSettings = clientSettings;
        }
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            // alternatively here is where you could 'inject' a RequiredAttribute into the attributes list
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            // Use whatever attributes you need here as parameters...
            if (_clientSettings.IsPropertyRequired(containerType, propertyName))
            {
                metadata.IsRequired = true;
            }
            return metadata;
        }
    }
