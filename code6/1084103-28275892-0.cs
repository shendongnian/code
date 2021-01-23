    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    public Type GetExpressionType(string expression, IDictionary<string, Type> variables)
    {
      var types = new List<ParameterExpression>();
      foreach (var varType in variables)
        types.Add(Expression.Parameter(varType.Value, varType.Key));
      var lamda = System.Linq.Dynamic.DynamicExpression.ParseLambda(types.ToArray(), null, expression);
      return lamda.ReturnType;
    }
