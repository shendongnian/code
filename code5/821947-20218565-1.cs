    public static class Extension
    {
        public static void RegisterNotify<T>(this T obj, Expression<Func<T, object>> propExpr, Action action) where T : INotifyPropertyChanged
        {
            string name = GetPropertyName(propExpr);
            obj.PropertyChanged += (s, e) => { if (e.PropertyName == name) action() };
        }
    }
