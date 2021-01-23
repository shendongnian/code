    [AttributeUsage(AttributeTargets.Property)]
    public class CustomHtmlAttribute : Attribute, IMetadataAware
    {
      public static string ValueKey
      {
        get { return "Value"; }
      }
      public string Value { get; set; }
      public void OnMetadataCreated(ModelMetadata metadata)
      {
        if (Value != null)
        {
          metadata.AdditionalValues[ValueKey] = Value;
        }
      }
    }
