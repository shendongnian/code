    public static class Extension
    {
        public static void RegisterNotify<T>(this T obj, Expression<Func<T, object>> propExpr, Action action) where T : INotifyPropertyChanged
        {
            // get property name from propExpr
            // register to obj.PropertyChanged
            // if name of property is correct, execute action
        }
    }
