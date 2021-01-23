    using System;
    using System.Linq.Expressions;
    using ConsoleApplication2;
    using System.Linq;
    class Program2
    {
        public static void Main(string[] args)
        {
            using (var db = new TestEntities())
            {
                var exp = db.complex_type_entity.Select(ComplexType.CreateExpression()).First();
            }
        }
    }
    public class SimpleType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public static Expression<Func<simple_type_entity, SimpleType>> CreateExpression()
        {
            var parameterExpr = Expression.Parameter(typeof(simple_type_entity), "p0");
            return Expression.Lambda<Func<simple_type_entity, SimpleType>>(CreateExpression(parameterExpr), parameterExpr);
        }
        public static MemberInitExpression CreateExpression(Expression sourceExpr)
        {
            return Expression.MemberInit(
                Expression.New(typeof(SimpleType)),
                Expression.Bind(typeof(SimpleType).GetProperty("Id"), Expression.Property(sourceExpr, "id")),
                Expression.Bind(typeof(SimpleType).GetProperty("Name"), Expression.Property(sourceExpr, "name")),
                Expression.Bind(typeof(SimpleType).GetProperty("Description"), Expression.Property(sourceExpr, "desc")));
        }
    }
    public class ComplexType
    {
        public Guid Id { get; set; }
        public SimpleType Property1 { get; set; }
        public SimpleType Property2 { get; set; }
        public static Expression<Func<complex_type_entity, ComplexType>> CreateExpression()
        {
            var parameterExp = Expression.Parameter(typeof(complex_type_entity), "p0");
            return Expression.Lambda<Func<complex_type_entity, ComplexType>>(
                Expression.MemberInit(
                    Expression.New(typeof(ComplexType)),
                    Expression.Bind(typeof(ComplexType).GetProperty("Id"), Expression.Property(parameterExp, "id")),
                    Expression.Bind(typeof(ComplexType).GetProperty("Property1"), SimpleType.CreateExpression(Expression.Property(parameterExp, "simple_type_entity"))),
                    Expression.Bind(typeof(ComplexType).GetProperty("Property2"), SimpleType.CreateExpression(Expression.Property(parameterExp, "simple_type_entity1")))),
            parameterExp);
        }
    }
