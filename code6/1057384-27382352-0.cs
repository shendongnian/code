     private static Expression<Func<IGrouping<IDictionary<string, object>, Respondent>, IDictionary<string, object>>> GetKey(String field)
     {
          // x => 
          var ParameterType = typeof(IGrouping<IDictionary<string, object>, Respondent>);
          var parameter = Expression.Parameter(ParameterType, "x");
          // x => x.Key
          var Key = Expression.Property(parameter, "Key");
          // x => x.Key[field]
          Expression KeyExpression = Expression.Property(Key, "Item", new Expression[] { Expression.Constant(field) });
          ParameterExpression KeyResult = Expression.Parameter(typeof(object));
          BlockExpression block = Expression.Block(
               new[] { KeyResult },
               Expression.Assign(KeyResult, KeyExpression),
               KeyResult
          );
          ....  // <- the block is put in the selector (as shown above)
     }
