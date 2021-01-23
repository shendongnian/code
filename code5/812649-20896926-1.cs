    public static class EntityFrameworkDataServiceProvider2Extensions
    {
        /// <summary>
        /// Gets the underlying data model currently used by an EntityFrameworkDataServiceProvider2.
        /// </summary>
        /// <remarks>
        /// TODO: Obsolete this method if the API changes to support access to the model.
        /// Reflection is used as a workaround because EntityFrameworkDataServiceProvider2 doesn't (yet) provide access to its underlying data source. 
        /// </remarks>
        public static T GetDataModel<T>(this EntityFrameworkDataServiceProvider2<T> efProvider) where T : class
        {
            if (efProvider != null)
            {
                Type modelType = typeof(T);
                // Get the innerProvider field info for an EntityFrameworkDataServiceProvider2 of the requested type
                FieldInfo ipField;
                if (!InnerProviderFieldInfoCache.TryGetValue(modelType, out ipField))
                {
                    ipField = efProvider.GetType().GetField("innerProvider", BindingFlags.NonPublic | BindingFlags.Instance);
                    InnerProviderFieldInfoCache.Add(modelType, ipField);
                }
                var innerProvider = ipField.GetValue(efProvider);
                if (innerProvider != null)
                {
                    // Get the CurrentDataSource property of the innerProvider
                    PropertyInfo cdsProperty;
                    if (!CurrentDataSourcePropertyInfoCache.TryGetValue(modelType, out cdsProperty))
                    {
                        cdsProperty = innerProvider.GetType().GetProperty("CurrentDataSource");
                        CurrentDataSourcePropertyInfoCache.Add(modelType, cdsProperty);
                    }
                    return cdsProperty.GetValue(innerProvider, null) as T;
                }
            }
            return null;
        }
        private static readonly ConditionalWeakTable<Type, FieldInfo> InnerProviderFieldInfoCache = new ConditionalWeakTable<Type, FieldInfo>();
        private static readonly ConditionalWeakTable<Type, PropertyInfo> CurrentDataSourcePropertyInfoCache = new ConditionalWeakTable<Type, PropertyInfo>();
    }
