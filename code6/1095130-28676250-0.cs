    public class DynamicContractResolver<T> : DefaultContractResolver
    {
        private readonly HashSet<string> propertiesToExclude;
        
        public DynamicContractResolver(
            params Expression<Func<T, object>>[] propertyExpressions)
        {
            this.propertiesToExclude = new HashSet<string>();
            
            foreach (Expression<Func<T, object>> expression in propertyExpressions)
            {
                string propertyName = GetPropertyNameFromExpression(expression);
                
                this.propertiesToExclude.Add(propertyName);
            }
        }
        
        protected override IList<JsonProperty> CreateProperties(
            Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> jsonProperties =
                base.CreateProperties(type, memberSerialization);
                    
            if (typeof(T).IsAssignableFrom(type))
            {
                jsonProperties = jsonProperties
                    .Where(pr => !this.propertiesToExclude.Contains(pr.PropertyName))
                    .ToList();
            }
            
            return jsonProperties;
        }
        
        // http://stackoverflow.com/a/2916344/497356
        private string GetPropertyNameFromExpression(
            Expression<Func<T, object>> expression)
        {
            MemberExpression body = expression.Body as MemberExpression;
            
            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)expression.Body;
                body = ubody.Operand as MemberExpression;
            }
            
            return body.Member.Name;
        }
    }
