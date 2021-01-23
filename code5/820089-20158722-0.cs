    class Program
    {
        public class Mapper<TEntity> where TEntity : class
        {
            private readonly Dictionary<string, Action<TEntity, object>> _propertyMappers = new Dictionary<string, Action<TEntity, object>>();
            private Func<TEntity> _entityFactory;
            public Mapper<TEntity> ConstructUsing(Func<TEntity> entityFactory)
            {
                _entityFactory = entityFactory;
                return this;
            }
            public Mapper<TEntity> Map<TProperty>(Expression<Func<TEntity, TProperty>> memberExpression, string bloombergFieldName, Expression<Func<object, TProperty>> converter)
            {
                var converterInput = Expression.Parameter(typeof(object), "converterInput");
                var invokeConverter = Expression.Invoke(converter, converterInput);
                var assign = Expression.Assign(memberExpression.Body, invokeConverter);
                var mapAction = Expression.Lambda<Action<TEntity, object>>(
                    assign, memberExpression.Parameters[0], converterInput).Compile();
                _propertyMappers[bloombergFieldName] = mapAction;
                return this;
            }
            public TEntity MapFrom(Dictionary<string, object> bloombergDict)
            {
                var instance = _entityFactory();
                foreach (var entry in bloombergDict)
                {
                    _propertyMappers[entry.Key](instance, entry.Value);
                }
                return instance;
            }
        }
        public class StockDataResult
        {
            public string Name { get; set; }
            public decimal LastPrice { get; set; }
            public DateTime SettlementDate { get; set; }
            public decimal EPS { get; set; }
        }
        public static void Main(params string[] args)
        {
            var mapper = new Mapper<StockDataResult>()
                .ConstructUsing(() => new StockDataResult())
                .Map(x => x.Name, "NAME", p => (string)p)
                .Map(x => x.LastPrice, "PX_LAST", p => Convert.ToDecimal((float)p))
                .Map(x => x.SettlementDate, "SETTLE_DT", p => DateTime.ParseExact((string)p, "MM/dd/yyyy", null));
            var dctBloombergStockData = new Dictionary<string, object>
            {
                { "NAME", "IBM" },
                {  "PX_LAST", 181.30f },
                { "SETTLE_DT", "11/25/2013" } // This is Datetime value
            };
            var myStockResult = mapper.MapFrom(dctBloombergStockData);
            Console.WriteLine(myStockResult.Name);
            Console.WriteLine(myStockResult.LastPrice);
            Console.WriteLine(myStockResult.SettlementDate);
        }
    }
