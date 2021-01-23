    namespace SafetyPlus.Shell.Code
    {
        public abstract class ExtendedPageBaseClass<TModel> : WebViewPage<TModel> where TModel : class
        {
            public T Data<T>(String key) 
            {
                return (T)Model.GetType().GetProperty(key).GetValue(Model);
            }
            public Object Data(String key) 
            {
                return Data<Object>(key);
            }
        }
    }
