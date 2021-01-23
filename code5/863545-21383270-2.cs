    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
         protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
         {
              base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
              foreach (var attribute in attributes.OfType<RangeAttribute>())
              {
                   if (attribute.OperandType == typeof(DateTime)
                   {
                        attribute.Maximum = DateTime.Now.AddDays(1).ToString();
                   }
              }
         }
    }
