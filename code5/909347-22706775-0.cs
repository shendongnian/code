        public static int Count<TSource>(this IQueryable<TSource> source) { 
            if (source == null)
                throw Error.ArgumentNull("source"); 
            return source.Provider.Execute<int>( 
                Expression.Call(
                    null, 
                    ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TSource)),
                    new Expression[] { source.Expression }
                    ));
        }
