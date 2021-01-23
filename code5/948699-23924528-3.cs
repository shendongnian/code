    public interface ITypeConverter<T>
    {
        bool CanConvertTo<TTarget>();
        TTarget ConvertTo<TTarget>(T value);
    }
    
    
    public interface IntConverter : ITypeConverter<long>
    {
        private class Op<TTarget>
        {
            public static Func<long, TTarget> ConvertTo;
        }
        
        static IntConverter()
        {
            Op<string>.ConvertTo = v => v.ToString();
            Op<DateTime>.ConvertTo = v => new DateTime(v);
        }
        
        public TTarget ConvertTo<TTarget>(T value)
        {
            return Op<TTarget>.ConvertTo(value);
        }
    }
