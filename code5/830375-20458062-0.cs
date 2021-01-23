    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    
    namespace ConvertExpression
    {
        public class BusinessObject
        {
            public int Value { get; set; }
        }
    
        public class DataObject
        {
            public int Value { get; set; }
        }
    
        internal class ExpressionConverter : ExpressionVisitor
        {
            public Expression Convert(Expression expr)
            {
                return Visit(expr);
            }
    
            private ParameterExpression replaceParam;
    
            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                if (typeof(T) == typeof(Func<BusinessObject, bool>))
                {
                    replaceParam = Expression.Parameter(typeof(DataObject), "p");
                    return Expression.Lambda<Func<DataObject, bool>>(Visit(node.Body), replaceParam);
                }
                return base.VisitLambda<T>(node);
            }
    
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node.Type == typeof(BusinessObject))
                    return replaceParam; // Expression.Parameter(typeof(DataObject), "p");
                return base.VisitParameter(node);
            }
    
            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.DeclaringType == typeof(BusinessObject))
                {
                    var member = typeof(DataObject).GetMember(node.Member.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).FirstOrDefault();
                    if (member == null)
                        throw new InvalidOperationException("Cannot identify corresponding member of DataObject");
                    return Expression.MakeMemberAccess(Visit(node.Expression), member);
                }
                return base.VisitMember(node);
            }
        }
    
        public class ConvertExpression
        {
            public static void Main()
            {
                BusinessObject[] bos = { new BusinessObject() { Value = 123 }, new BusinessObject() { Value = 246 } };
                DataObject[] dos = { new DataObject() { Value = 123 }, new DataObject() { Value = 246 } };
                Expression<Func<BusinessObject, bool>> boExpr = x => x.Value == 123;
                var conv = new ExpressionConverter();
                Expression<Func<DataObject, bool>> doExpr = (Expression<Func<DataObject, bool>>) conv.Convert(boExpr);
    
                var selBos = bos.Where(boExpr.Compile());
                Console.WriteLine("Matching BusinessObjects: {0}", selBos.Count());
                foreach (var bo in selBos)
                    Console.WriteLine(bo.Value);
                var compDoExpr = doExpr.Compile();
                var selDos = dos.Where(doExpr.Compile());
                Console.WriteLine("Matching DataObjects: {0}", selDos.Count());
                foreach (var dataObj in selDos)
                    Console.WriteLine(dataObj.Value);
                Console.ReadLine();
            }
        }
    }
