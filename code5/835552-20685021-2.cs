    public class CustomViewModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        public override IEnumerable<ModelMetadata> GetMetadataForProperties(object container, Type containerType)
        {
            if (containerType == null)
            {
                throw new ArgumentNullException("containerType");
            }
            return GetMetadataForPropertiesImpl(container, containerType);
        }
        private IEnumerable<ModelMetadata> GetMetadataForPropertiesImpl(object container, Type containerType)
        {
			var propertiesMetadata = new List<ModelMetadata>();
			foreach (EntityProp eprop in ((Entity)container).Props.Values)
			{
				Func<object> modelAccessor = () => eprop;
				propertiesMetadata.add(GetMetadataForProperty(modelAccessor, containerType, eprop.Name));
			}
			return propertiesMetadata;  // List returned instead of yielding, hoping not be needed to re-call this method more than once
        }
		
		public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName) {
            if (containerType == null) {
                throw new ArgumentNullException("containerType");
            }
            if (String.IsNullOrEmpty(propertyName)) {
                throw new ArgumentException(MvcResources.Common_NullOrEmpty, "propertyName");
            }
            return CreateMetadata(null, containerType, modelAccessor, modelAccessor().Type, propertyName);
        }
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
			EntityProp eprop = modelAccessor();
			DataAnnotationsModelMetadata result;
			if (propertyName == null)
			{
				// You have the main object
				return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
			}
			else
			{
				// You have here the property object
				result = new DataAnnotationsModelMetadata(this, containerType, () => eprop.Value, modelType, propertyName, null);
				result.IsRequired = eprop.IsRequired;
			}
			return result;
		}
    }
