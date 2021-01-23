    public class LongConverter : ITypeConverter<long>
    {
        private static class Op<TTarget>
        {
            public static Func<long, TTarget> ConvertTo;
        }
        
        static LongConverter()
        {
            Op<string>.ConvertTo = v => v.ToString();
            Op<DateTime>.ConvertTo = v => new DateTime(v);
            Op<int>.ConvertTo = v => (int)v;
        }
        
        public TTarget ConvertTo<TTarget>(T value)
        {
            return Op<TTarget>.ConvertTo(value);
        }
    }
