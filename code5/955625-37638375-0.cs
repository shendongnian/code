    class CamelCaseExceptDictionaryResolver : CamelCasePropertyNamesContractResolver
        {
            #region Overrides of DefaultContractResolver
    
            protected override string ResolveDictionaryKey(string dictionaryKey)
            {
                return dictionaryKey;
            }
    
            #endregion
        }
