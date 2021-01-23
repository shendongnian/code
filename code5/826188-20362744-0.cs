    public class MyCustomResolver : CamelCasePropertyNamesContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName == "Links" ? "_links" : base.ResolvePropertyName(propertyName);
        }
    }
