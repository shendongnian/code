    public class ProductsInformationQuery<TResultType, TIdType>: Query<TResultType> 
        where TResultType : Product
    {
        private readonly List<TIdType> _ids;
        private readonly Expression<Func<TResultType, object>> _func;
    
        public ProductsInformationQuery(
            List<TIdType> ids, 
            FeaturedIdType featureIdType, 
            Expression<System.Func<TResultType, TIdType>> func)
        {
            _ids = ids;
			
            System.Linq.Expressions.Expression converted = 
                System.Linq.Expressions.Expression.Convert(func.Body, typeof(object));
			
            _func = System.Linq.Expressions.Expression.Lambda<Func<TResultType, object>>
               (converted, func.Parameters);
        }
    
        public override List<TResultType> Execute()
        {
            return Session.QueryOver<TResultType>()
				.Where(Restrictions.On<TResultType>(_func)
					.IsIn(_ids.ToArray())
				.List()
				.ToList();
        }
    }
