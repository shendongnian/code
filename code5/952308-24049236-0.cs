    /// <summary>
    /// Builds the mapping expression.
    /// </summary>
    /// <param name="descriptor">The descriptor.</param>
    /// <param name="reader">The reader.</param>
    /// <returns>LambdaExpression.</returns>
    public static Expression<Func<IDataRecord, object>> BuildMappingExpression(IDescriptor descriptor, IDataRecord reader, string[] availableColumns)
    {
        var statements = new List<Expression>();
        ParameterExpression readerExp = Expression.Parameter(typeof(IDataRecord));
        ParameterExpression descriptorExp = Expression.Variable(descriptor.GetDescriptorType(), "descriptor");
        BinaryExpression createInstanceExp = Expression.Assign(
            descriptorExp, Expression.New(descriptor.GetDescriptorType()));
        statements.Add(createInstanceExp);
        foreach (KeyValuePair<PropertyInfo, PropertyMapping> pair in descriptor.ReadablePropertiesAndDataNames
            .Where(property => availableColumns.Contains(property.Value.ReturnName.ToUpper(CultureInfo.InvariantCulture))))
        {
            MemberExpression propertyExp = Expression.Property(descriptorExp, pair.Key);
            IndexExpression readValue =
                Expression.MakeIndex(readerExp, typeof(IDataRecord).GetProperty("Item", new[] { typeof(string) }),
                new[] { Expression.Constant(pair.Value.ReturnName) });
            MethodCallExpression castValueExp =
                Expression.Call(typeof(Descriptor)
                    .GetMethod("CastValue",
                        BindingFlags.Static | BindingFlags.Public,
                        null,
                        new Type[]
                        {
                            typeof(Type), typeof(object), typeof(object)
                        },
                        null), Expression.Constant(pair.Key.PropertyType, typeof(Type)), readValue, Expression.Constant(null));
            BinaryExpression assignmentExp = Expression.Assign(propertyExp, Expression.Convert(castValueExp, pair.Key.PropertyType));
            statements.Add(assignmentExp);
        }
        statements.Add(descriptorExp);
        var body = Expression.Block(new ParameterExpression[] { descriptorExp }, statements);
        return Expression.Lambda<Func<IDataRecord, object>>(body, readerExp);
    }
