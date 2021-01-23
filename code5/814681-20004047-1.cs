    public class ClientSettingsProvider
    {
        public ClientSettingsProvider(/* db info */) { /* init */ }
    
        public bool IsPropertyRequired(string propertyIdentifier)
        {
           // check the property identifier here and return status
        }
    
    }
    public ClientRequiredAttribute : Attribute
    {
        string _identifier;
        public string Identifier { get { return _identifer; } }
        public ClientRequiredAttribute(string identifier)
        { _identifier = identifier; }
    }
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
            var clientRequiredAttribute = attributes.OfType<ClientRequiredAttribute>().SingleOrDefault();
            if(clientRequiredAttribute != null && _clientSettings.IsPropertyRequired(clientRequiredAttribute.Identifier))
            {
                // By injecting the Required attribute here it will seem to 
                // the base provider we are extending as if the property was
                // marked with [Required]. Your data validation attributes should
                // be added, provide you are using the default editor templates in
                // you view.
                attributes = attributes.Union(new [] { new RequiredAttribute() });
            }
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            // REMOVED, this is another way but I'm not 100% sure it will add your attributes
            // Use whatever attributes you need here as parameters...
            //if (_clientSettings.IsPropertyRequired(containerType, propertyName))
            //{
            //    metadata.IsRequired = true;
            //}
            return metadata;
        }
    }
