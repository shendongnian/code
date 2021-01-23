     public class LambdaGeneratorFactory<T>
        {
            //This is an ugly implementation of a Factory pattern.
            //You should improve this possibly with interfaces, maybe abstract factory.
            public Predicate<T> Run(Criteria criteria)
            {
                if (typeof(T) == typeof (Receipt))
                {
                    return CreateLambda(criteria);
                }
                else if (typeof (T) == typeof (ICollection<ReceiptDetail>))
                {
                    return CreateLambdaWithCount(criteria);
                }
    
                return null;
            }
            private  Predicate<T> CreateLambda(Criteria criteria)
            {
                ParameterExpression pe = Expression.Parameter(typeof(T), "i");
    
                Expression left = Expression.Property(pe, typeof(T).GetProperty(criteria.Property));
                Expression right = Expression.Constant(criteria.Value);
    
                
                Expression predicateBody = Expression.Equal(left, right);
    
                var predicate = Expression.Lambda<Predicate<T>>(predicateBody, new ParameterExpression[] { pe }).Compile();
    
                return predicate;
            }
    
            private Predicate<T> CreateLambdaWithCount(Criteria criteria)
            {
                ParameterExpression pe = Expression.Parameter(typeof(T), "i");
    
                Expression count = Expression.Property(pe, typeof(T).GetProperty("Count"));
                Expression left = Expression.Call(count, typeof(Object).GetMethod("ToString"));
                Expression right = Expression.Constant(criteria.Value);
    
                
                Expression predicateBody = Expression.Equal(left, right);
    
                var predicate = Expression.Lambda<Predicate<T>>(predicateBody, new ParameterExpression[] { pe }).Compile();
    
                return predicate;
            }
        }
