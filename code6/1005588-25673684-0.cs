    static class ConverterHolder<TIn, TOut> {
        public static Func<TIn, TOut> Converter;
        static ConverterHolder() {
            var parameter = Expression.Parameter(typeof(TIn));
            Converter = Expression.Lambda<Func<TIn, TOut>>(
                Expression.Convert(parameter, typeof(TOut)), 
                parameter
            );
        }
    }
