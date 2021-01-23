    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    static class Program
    {
        static void Main()
        {
            double d = 100;
    
            Expression<Func<double, double>> ex1 = x => -x;
            Expression<Func<double>> ex2 = () => -d;
    
            var result1 = Demungify(ex1); // (x) => -x
            var result2 = Demungify(ex2); // () => -100
        }
    
        public static LambdaExpression Demungify(LambdaExpression ex)
        {
            var visitor = new Demungifier();
            var newBody = visitor.Visit(ex.Body);
            return Expression.Lambda(newBody, ex.Parameters.Where(visitor.WasSeen));
        }
        class Demungifier : ExpressionVisitor
        {
            readonly HashSet<ParameterExpression> parameters = new HashSet<ParameterExpression>();
            
            public bool WasSeen(ParameterExpression param)
            {
                return parameters.Contains(param);
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                parameters.Add(node);
                return base.VisitParameter(node);
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                object value;
                if(TryEvaluate(node, out value))
                {
                    return Expression.Constant(value, ((FieldInfo)node.Member).FieldType);
                }
                return base.VisitMember(node);
            }
            bool TryEvaluate(Expression expression, out object value)
            {
                if(expression == null)
                {
                    value = null;
                    return true;
                }
                if(expression.NodeType == ExpressionType.Constant)
                {
                    value = ((ConstantExpression)expression).Value;
                    return true;
                }
                // captured variables are always fields, potentially of fields of fields
                // eventually terminating in a ConstantExpression that is the capture-context
                MemberExpression member;
                if(expression.NodeType == ExpressionType.MemberAccess
                    && (member= (MemberExpression)expression).Member.MemberType == System.Reflection.MemberTypes.Field)
                {
                    object target;
                    if(TryEvaluate(member.Expression, out target))
                    {
                        value = ((FieldInfo)member.Member).GetValue(target);
                        return true;
                    }
                }
                value = null;
                return false;
            }
    
        }
    }
