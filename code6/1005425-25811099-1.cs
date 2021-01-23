      public class ODataFilterConverter
      {
        private readonly IEdmModel m_model;
        public ODataFilterConverter(TestRestApiEntities db)
        {
          m_model = db.GetEdm(); // *Breeze Labs: EdmBuilder*
        }
    
        public Expression<Func<T, bool>> Convert<T>(string odataString)
        {
          var filterQueryOption = GetFilterQueryOption(GetQueryContext<T>(), odataString);
    
          return GetFilterExpression<T>(filterQueryOption);
        }
    
        private ODataQueryContext GetQueryContext<T>()
        {
          return new ODataQueryContext(m_model, typeof(T));
        }
    
        private FilterQueryOption GetFilterQueryOption(ODataQueryContext queryContext, string filter)
        {
          return new FilterQueryOption(filter, queryContext);
        }
    
        static private Expression<Func<T, bool>> GetFilterExpression<T>(FilterQueryOption filter)
        {
          var enumerable = Enumerable.Empty<T>().AsQueryable();
          var param = Expression.Parameter(typeof(T));
          if (filter != null)
          {
            enumerable = (IQueryable<T>)filter.ApplyTo(enumerable, new ODataQuerySettings());
    
            var mce = enumerable.Expression as MethodCallExpression;
            if (mce != null)
            {
              var quote = mce.Arguments[1] as UnaryExpression;
              if (quote != null)
              {
                return quote.Operand as Expression<Func<T, bool>>;
              }
            }
          }
          return Expression.Lambda<Func<T, bool>>(Expression.Constant(true), param);
        }
      }
