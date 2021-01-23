    public static class ExtensionMethods
    {
        public static bool Remove<T>(this ObservableCollection<T> collection)
        {
            var someObject;
            // custom logic here
            return collection.Remove(someObject);
        }
    }  
