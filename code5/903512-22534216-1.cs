    private readonly Dictionary<Type, Func<Object, String>> queryBuilders =
       new Dictionary<Type, Func<object, string>>();
    public String GetInsertQuery(Object entity)
    {
       var type = entity.GetType();
       if (!queryBuilders.ContainsKey(type))
       {
          var param = Expression.Parameter(typeof(Object), "entity");
          var typedObject = Expression.Variable(type, "obj");
          var stringBuilder = Expression.Variable(typeof (StringBuilder), "sb");
          var appendString = typeof (StringBuilder).GetMethod("Append", new[] {typeof (String)});
          var objectToString = typeof(Object).GetMethod("ToString");
          var code = new List<Expression>();
          code.Add(Expression.Assign(typedObject, Expression.Convert(param, type)));
          code.Add(Expression.Assign(stringBuilder, Expression.New(typeof (StringBuilder))));
          code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant(string.Format("INSERT INTO {0} (", type.Name))));
          var properties = type.GetProperties();
          for (int i = 0; i < properties.Length - 1; i++)
          {
             code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant(properties[i].Name)));
             code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant(", ")));
          }
          code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant(properties[properties.Length - 1].Name)));
          code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant(") VALUES (")));
          for (int i = 0; i < properties.Length - 1; i++)
          {
             code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant("'")));
             code.Add(Expression.Call(stringBuilder, appendString, Expression.Call(Expression.Property(typedObject, properties[i]), objectToString)));
             code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant("', ")));
          }
          code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant("'")));
          code.Add(Expression.Call(stringBuilder, appendString, Expression.Call(Expression.Property(typedObject, properties[properties.Length - 1]), objectToString)));
          code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant("', ")));
          code.Add(Expression.Call(stringBuilder, appendString, Expression.Constant(");")));
          code.Add(Expression.Call(stringBuilder, "ToString", new Type[] { }));
          var expression = Expression.Lambda<Func<Object, String>>(Expression.Block(new[] { typedObject, stringBuilder }, code), param);
          queryBuilders[type] = expression.Compile();
       }
       return queryBuilders[type](entity);
    }
