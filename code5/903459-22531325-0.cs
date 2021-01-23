    public class ResourceInstance<T>
        where T : ResourceInstance<T> // To ensure correct usage
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
    
                var name = typeof(T).Name;
                _instance = (T)Application.Current.TryFindResource(name);
    
                return _instance;
            }
        }
    }
    public class FooConverter : ResourceInstance<FooConverter>, IValueConverter
    {
        ...
    }
