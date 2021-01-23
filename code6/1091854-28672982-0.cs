     public class SimpleCacheKeyGenerator
    {
        public string GetCacheKey<T, TObject>(Expression<Func<T, TObject>> action)
        {
            var body = (MethodCallExpression) action.Body;
            ICollection<object> parameters = body.Arguments.Select(x => ((ConstantExpression) x).Value).ToList();
            var sb = new StringBuilder(100);
            sb.Append(body.Type.Namespace);
            sb.Append("-");
            sb.Append(body.Method.Name);
            parameters.ToList().ForEach(x =>
            {
                sb.Append("-");
                sb.Append(x);
            });
            return sb.ToString();
        }
    }
    public class InMemoryCache
    {
        public void Get<T, TObject>(Expression<Func<T, TObject>> getItemCallback)
        {
            var generator = new SimpleCacheKeyGenerator();
            Console.WriteLine(generator.GetCacheKey(getItemCallback));
        }
    }
