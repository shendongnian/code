    <#
    foreach (PropertyMetadata property in ModelMetadata.Properties) {
    var T = Type.GetType(ViewDataTypeName+", TestSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
    var ss = System.Web.Mvc.ModelMetadataProviders.Current.GetMetadataForProperty(null ,T ,property.PropertyName );#>
    <#= ss.IsRequired #>
