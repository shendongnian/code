    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    namespace ExpressionTrees
    {
        public static class ExpressionTreeBuilder
        {
            private static readonly IDictionary<string, Delegate> Lambdas = 
                new Dictionary<string, Delegate>();
            public static T GetValue<T, TInst>(this TInst obj, string propPath, T defVal = default(T))
            {
                var key = String.Format("{0};{1}", propPath, typeof(T).Name);
                Delegate del;
                if (!Lambdas.TryGetValue(key, out del))
                {
                    var instance = Expression.Parameter(typeof(TInst), "obj");
                    var currentExpression = 
                        propPath
                        .Split('.')
                        .Aggregate((Expression)instance, (current, path) => current.GetPropertyValueExpr(path));
                    var lexpr = Expression.Lambda<Func<TInst, T>>(currentExpression, instance);
                    del = lexpr.Compile();
                    Lambdas.Add(key, del);
                }
                var action = (Func<TInst, T>)del;
                return action.Invoke(obj);
            }
            public static Expression GetPropertyValueExpr(this Expression obj, string propName)
            {
                var field = Expression.PropertyOrField(obj, propName);
                var expr = Expression.Convert(field, field.Type);
                return expr;
            }
        }
    }
