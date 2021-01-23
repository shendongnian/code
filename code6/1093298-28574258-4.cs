    private static Func<string[], T> CreateCsvDeserializer<T>(string[] columnNames)
        where T : new()
    {
        var resultVariable = Expression.Variable(typeof (T), "result");
        var csvFieldsParameter = Expression.Parameter(typeof (string[]), "csvFields");
        var constructorCall = Expression.Assign(resultVariable, Expression.New(typeof (T)));
        //will contain all code lines that implement the method
        var codeLines = new List<Expression> {constructorCall};
        for (int i = 0; i < columnNames.Length; i++)
        {
            string columnName = columnNames[i];
            PropertyInfo property = typeof (T).GetProperty(columnName);
            if (property == null || !property.CanWrite || !property.GetSetMethod().IsPublic)
            {
                //cannot write to property
                throw new Exception();
            }
            //Convert.ChangeType(object, Type)
            var convertChangeTypeMethod = typeof (Convert).GetMethod("ChangeType",
                new[] {typeof (object), typeof (Type)});
            //csvFields[i]
            var getColumn = Expression.ArrayIndex(csvFieldsParameter, Expression.Constant(i));
            //Convert.ChangeType(csvFields[i], [propertyType])
            var conversion = Expression.Call(convertChangeTypeMethod, getColumn,
                Expression.Constant(property.PropertyType));
            //([propertyType])Convert.ChangeType(csvFields[i], [propertyType])
            var cast = Expression.Convert(conversion, property.PropertyType);
            //result.[property]
            var propertyExpression = Expression.Property(resultVariable, property);
            //result.[property] = ([propertyType])Convert.ChangeType(csvFields[i], [propertyType])
            codeLines.Add(Expression.Assign(propertyExpression, cast));
        }
        //create a line that returns the resultVariable
        codeLines.Add(resultVariable);
            
        //now, we have a list of code lines, it's time to build our function
        Type returnType = typeof (T);
        var variablesUsed = new[] {resultVariable};
        var codeBlock = Expression.Block(returnType, variablesUsed, codeLines);
        var parameterList = new[] {csvFieldsParameter};
        return Expression.Lambda<Func<string[], T>>(codeBlock, parameterList).Compile();
    } 
