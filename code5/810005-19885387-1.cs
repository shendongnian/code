        ParameterExpression @object = Expression.Parameter(typeof(StudentPacket), "@object");
        MethodInfo serializeMethodInfo = typeof(BinaryFormatter).GetMethod("Serialize", new Type[] { typeof(Stream), typeof(object) });
        MethodInfo toArrayMethodInfo = typeof(MemoryStream).GetMethod("ToArray");
        var bf = Expression.Variable(typeof(BinaryFormatter), "bf");
        var ms = Expression.Variable(typeof(System.IO.MemoryStream), "ms");
        List<Expression> expressions = new List<Expression>();
        expressions.Add(
            Expression.Assign(bf, Expression.New(typeof(BinaryFormatter))));
        expressions.Add(
            Expression.Assign(ms, Expression.New(typeof(MemoryStream))));
        foreach (FieldInfo field in typeof(StudentPacket).GetFields())
        {
            expressions.Add(
               Expression.Call(bf, serializeMethodInfo, ms, 
                               Expression.Convert(Expression.Field(@object, field.Name),
                                                  typeof(object))));
        }
        expressions.Add(Expression.Call(ms, toArrayMethodInfo));
        var lambda = Expression.Lambda(
            Expression.Block(
                new[] { bf, ms },
                expressions
            ),
            @object);
