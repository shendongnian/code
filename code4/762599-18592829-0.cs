    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Objects.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    namespace Crawlr.Web.Code
    {
        public static class ObjectSetExExtensions
        {
            public static ObjectSetEx<T> Extend<T>(this IQueryable<T> self) where T : class
            {
                return new ObjectSetEx<T>(self);
            }
        }
        public class ObjectSetEx<T> : IOrderedQueryable<T>
        {
            private readonly QueryProviderEx provider;
            private readonly IQueryable<T> source;
            public ObjectSetEx(IQueryable<T> source)
            {
                this.source = source;
                provider = new QueryProviderEx(this.source.Provider);
            }
            #region IQueryableEx<T> Members
            public IEnumerator<T> GetEnumerator()
            {
                return source.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return source.GetEnumerator();
            }
            public Type ElementType
            {
                get { return source.ElementType; }
            }
            public Expression Expression
            {
                get { return source.Expression; }
            }
            public IQueryProvider Provider
            {
                get { return provider; }
            }
            #endregion
        }
        public class QueryProviderEx : IQueryProvider
        {
            private readonly IQueryProvider source;
            public QueryProviderEx(IQueryProvider source)
            {
                this.source = source;
            }
            #region IQueryProvider Members
            public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            {
                Expression newExpression = ExpressionReWriterVisitor.Default.Visit(expression);
                IQueryable<TElement> query = source.CreateQuery<TElement>(newExpression);
                return new ObjectSetEx<TElement>(query);
            }
            public IQueryable CreateQuery(Expression expression)
            {
                Expression newExpression = ExpressionReWriterVisitor.Default.Visit(expression);
                IQueryable query = source.CreateQuery(newExpression);
                return query;
            }
            public TResult Execute<TResult>(Expression expression)
            {
                Expression newExpression = ExpressionReWriterVisitor.Default.Visit(expression);
                return source.Execute<TResult>(newExpression);
            }
            public object Execute(Expression expression)
            {
                Expression newExpression = ExpressionReWriterVisitor.Default.Visit(expression);
                return source.Execute(newExpression);
            }
            #endregion
        }
        public class ExpressionReWriterVisitor : ExpressionVisitor
        {
            public static readonly ExpressionReWriterVisitor Default = new ExpressionReWriterVisitor();
            protected override Expression VisitUnary(UnaryExpression node)
            {
                if (node.NodeType == ExpressionType.Convert && node.Operand.Type == typeof(int) && node.Type==typeof(object))
                {
                    var operand = node.Operand;
                    var stringConvertMethod = typeof(SqlFunctions).GetMethod("StringConvert", new Type[] { typeof(double?) });
                    var trimMethod = typeof(string).GetMethod("Trim",new Type[] {});
                
                    var dOperand = Expression.Convert(operand, typeof(double?));
                    return Expression.Call(Expression.Call(stringConvertMethod, dOperand),trimMethod);
                }
            
                return base.VisitUnary(node);
            }      
        }
    }
