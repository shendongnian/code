    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
              Type containerType, Func<object> modelAccessor, 
              Type modelType, string propertyName)
        { 
             var modelMetadata = base.CreateMetadata(attributes, containerType, 
                     modelAccessor, modelType, propertyName);
              
             if (attributes.OfType<MyDisplay>().ToList().Count > 0)
             {
                  modelMetadata.DisplayName = GetValueFromLocalizationAttribute(attributes.OfType<MyDisplay>().ToList()[0]);
             }
             return modelMetadata;
        }
        private string GetValueFromLocalizationAttribute(MyDisplay attribute)
        {
              return computedValueBasedOnCodeAndLanguage;
        }
    }
