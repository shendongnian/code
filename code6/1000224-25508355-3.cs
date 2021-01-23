    private static IEnumerable<Expression> GetConditionsWithSubModel(string search, ParameterExpression pe,
        string parameter)
    {
        //         output.Where(d => d.JN_NewsCategories.NewsCategoriesEn.Contains(""));
        var expressions = new List<Expression>();
        var strings = parameter.Split('$');
        var modelName = strings[0];
        var subModelName = strings[1].Split('.')[0];
        var subModelField = strings[1].Split('.')[1];
    
        foreach (var splitSeacrh in search.Split(' '))
        {
            Type modelClass = GetModel(modelName);
            Type submodelClass = GetModel(subModelName);
            Expression leftSubModel = Expression.Property(pe, modelClass.GetProperty(subModelName));
            Expression ex = Expression.Property(leftSubModel, submodelClass.GetProperty(subModelField));
            Expression rightSubModel = Expression.Constant(splitSeacrh);
            MethodCallExpression conditionExpressionSubModel = Expression.Call(ex,
                typeof(string).GetMethod("Contains"), rightSubModel);
    
            expressions.Add(conditionExpressionSubModel);
        }
    
        return expressions;
    }
