    namespace Sitecore.ContentSearch
    {
        public interface IIndexFieldNameFormatterAttribute : _Attribute
        {
            string GetIndexFieldName(string fieldName);
    
            string GetTypeFieldName(string fieldName);
        }
    }
