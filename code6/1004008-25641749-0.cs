    public static Field GetSitecoreField<T>(T model, Expression<Func<T, object>> expression) where T : ModelBase
        {
            var body = ((MemberExpression)expression.Body);
            var attributes = typeof(T).GetProperty(body.Member.Name).GetCustomAttributes(typeof(SitecoreFieldAttribute), false);
            if (attributes.Any())
            {
                var attribute = attributes[0] as SitecoreFieldAttribute;
                if (attribute != null)
                {
                    return model.Item.Fields[attribute.FieldName];
                }
            }
            return null;
        }
