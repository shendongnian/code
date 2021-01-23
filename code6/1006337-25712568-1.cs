    namespace Glass.Sitecore.Mapper.Configuration.Attributes
    {
        /// <summary>
        /// Used to populate the property with data from a Sitecore field
        /// </summary>
        public class SitecoreFieldAttribute: AbstractSitecorePropertyAttribute, IIndexFieldNameFormatterAttribute 
        {
            public string GetIndexFieldName(string fieldName)
            {
                return this.FieldName;
            }
    
            public string GetTypeFieldName(string fieldName)
            {
                return fieldName;
            }
