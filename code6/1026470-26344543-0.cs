    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Reflection;
    
    public class User // convert from...
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Person // convert to...
    {
        public string Name { get; set; }
    }
    
    public class UserTransaction
    {
        public User FromUser { get; set; }
        public User ToUser { get; set; }
        public decimal Amount { get; set; }
    }
    
    public class PersonTransaction
    {
        public Person FromPerson { get; set; }
        public Person ToPerson { get; set; }
        public bool IsPositive { get; set; }
    }
    
    static class Program
    {
    
        static void Main()
        {
            Expression<Func<User, Person>> ToPerson = u => new Person { Name = u.FirstName + " " + u.LastName };
            Expression<Func<UserTransaction, PersonTransaction>> PersonTransaction = ut => new PersonTransaction
            {
                FromPerson = ToPerson.Compile()(ut.FromUser), // Actually, I do not want to compile
                ToPerson = ToPerson.Compile()(ut.ToUser), // (or double code)
                IsPositive = ut.Amount > 0
            };
            var visitor = new RemoveCompilationsExpressionVisitor();
    
            
            var inlined = (Expression<Func<UserTransaction, PersonTransaction>>)visitor.Visit(PersonTransaction);
        }
    
        class ParameterSwapExpressionVisitor :ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, Expression> swaps;
    
            public ParameterSwapExpressionVisitor(Dictionary<ParameterExpression, Expression> swaps)
            {
                this.swaps = swaps;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                Expression result;
                return swaps.TryGetValue(node, out result) ? result : base.VisitParameter(node);
            }
        }
        class RemoveCompilationsExpressionVisitor : ExpressionVisitor
        {
            protected override Expression VisitInvocation(InvocationExpression node)
            {
                var lambda = TryGetInnerLambda(node.Expression);
                if(lambda != null)
                {
                    // this would be a partial solution, but we want to go further!
                    // return Expression.Invoke(lambda, node.Arguments);
    
                    var swaps = new Dictionary<ParameterExpression, Expression>();
                    for(int i = 0; i < lambda.Parameters.Count; i++)
                    {
                        swaps.Add(lambda.Parameters[i], node.Arguments[i]);
                    }
                    var visitor = new ParameterSwapExpressionVisitor(swaps);
                    return visitor.Visit(lambda.Body);
                }
                return base.VisitInvocation(node);
            }
    
            LambdaExpression TryGetInnerLambda(Expression node)
            {
                try
                {
                    if(node.NodeType == ExpressionType.Call)
                    {
                        var mce = (MethodCallExpression)node;
                        var method = mce.Method;
                        if (method.Name == "Compile" && method.DeclaringType.IsGenericType && method.DeclaringType.GetGenericTypeDefinition()
                            == typeof(Expression<>))
                        {
                            object target;
                            if (TryGetLiteral(mce.Object, out target))
                            {
                                return (LambdaExpression)target;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    /* best effort only */
                    Debug.WriteLine(ex);
                }
                return null;
            }
    
            static bool TryGetLiteral(Expression node, out object value)
            {
                value = null;
                if (node == null) return false;
                switch(node.NodeType)
                {
                    case ExpressionType.Constant:
                        value = ((ConstantExpression)node).Value;
                        return true;
                    case ExpressionType.MemberAccess:
                        var me = (MemberExpression)node;
                        object target;
                        if (TryGetLiteral(me.Expression, out target))
                        {
                            switch (me.Member.MemberType)
                            {
                                case System.Reflection.MemberTypes.Field:
                                    value = ((FieldInfo)me.Member).GetValue(target);
                                    return true;
                                case MemberTypes.Property:
                                    value = ((PropertyInfo)me.Member).GetValue(target, null);
                                    return true;
                            }
                        }
                        break;
    
                }
                return false;
            }
        }
    
    }
