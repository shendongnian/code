    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
         protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
         {
              foreach (var attribute in attributes.OfType<RangeAttribute>())
              {
                   attribute.Maximum = DateTime.Now.AddDays(1).ToString();
              }
         }
    }
