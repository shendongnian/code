    class TypeConverter
    {
        private readonly IDictionary<Type, Delegate> map = new Dictionary<Type, Delegate>();
    
        public void Register<TInput, TOutput>(Converter<TInput, TOutput> converter)
        {
            if (converter == null)
                throw new ArgumentNullException("converter");
    
            this.map.Add(typeof(TInput), converter);
        }
    
        public TOutput Convert<TInput, TOutput>(TInput value)
        {
            return ((Converter<TInput, TOutput>)this.map[typeof(TInput)])(value);
        }
    
        public object Convert(object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
    
            return this.map[value.GetType()].DynamicInvoke(value);
        }
    }
