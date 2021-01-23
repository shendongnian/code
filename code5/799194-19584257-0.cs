    public static class GlobalFormAccessor
    {
        private static Dictionary<Type, object> _cache = new Dictionary<Type, object>();
        public static TForm GetForm<TForm>()
            where TForm : class, new()
        {
            if (_cache.ContainsKey(typeof(TForm)))
            {
                _cache[typeof(TForm)] = new TForm();
            }
            return (TForm)_cache[typeof(TForm)];
        }
        public static void SetForm<TForm>(TForm form)
        {
            _cache[typeof (TForm)] = form;
        }
    }
