    using LatticeUtils;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Common.CommandTrees;
    using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Authorisation
    {
      public static class DbPropertyExpressionProjector
      {
        /// <summary>
        /// Constructs an anonymous function that returns a DbExpression and expects an Anonymous Type.
        /// Supports the ability to dynamically create the following lambda:
        /// p => new {
        ///   Column1 = p.Property("l").Property("Column1")
        /// }
        /// </summary>
        /// <param name="fields">List of column names</param>
        /// <returns>Func<DbExpression,T></returns>
        public static LambdaExpression CreateLambdaExpression(Dictionary<string, string> fields)
        {
          Type type = Type.GetType("System.Func`2");
    
          Type[] anonymousTypeArguments = fields.Keys.Select(p => typeof(DbPropertyExpression)).ToArray();
          Type anonymousType = AnonymousTypeUtils.CreateGenericTypeDefinition(fields.Keys);
          anonymousType = anonymousType.MakeGenericType(anonymousTypeArguments);
    
          Type[] typeArguments = new[] { typeof(DbExpression), anonymousType };
          var lambdaType = type.MakeGenericType(typeArguments);
    
          var pParam = Expression.Parameter(typeof(DbExpression), "p");
          ParameterExpression[] parameters = { pParam };
    
          ConstructorInfo constructor = anonymousType.GetConstructors().SingleOrDefault();
    
          MethodInfo memberInfo = typeof(DbExpressionBuilder).GetMethods().FirstOrDefault(m => m.ToString() == "System.Data.Entity.Core.Common.CommandTrees.DbPropertyExpression Property(System.Data.Entity.Core.Common.CommandTrees.DbExpression, System.String)");
    
          List<Expression> argumentList = new List<Expression>();
          List<MemberInfo> membersList = new List<MemberInfo>();
    
          foreach (string field in fields.Keys)
          {
            Expression[] leftTableExpressions = { pParam, Expression.Constant(fields[field]) };
            Expression methodCallExpression = Expression.Call(null, memberInfo, leftTableExpressions);
    
            Expression[] secondPropertyExpressions = { methodCallExpression, Expression.Constant(field) };
            argumentList.Add(Expression.Call(null, memberInfo, secondPropertyExpressions));
            membersList.Add(anonymousType.GetMembers().FirstOrDefault(m => m.ToString() == string.Format("System.Data.Entity.Core.Common.CommandTrees.DbPropertyExpression {0}", field)));
          }
    
          var body = Expression.New(constructor, argumentList, membersList);
    
          return Expression.Lambda(lambdaType, body, parameters);
        }
      }
    }
