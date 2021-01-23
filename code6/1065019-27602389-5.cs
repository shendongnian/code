    class Program
    {
        static void Main(string[] args)
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
            return arg => new SimpleType
            {
                Id = arg.id,
                Name = arg.name,
                Description = arg.desc
            };
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
                    Expression.Bind(typeof(ComplexType).GetProperty("Property1"), CreateNewSimpleTypeExpression(parameterExp, "simple_type_entity")),
                    Expression.Bind(typeof(ComplexType).GetProperty("Property2"), CreateNewSimpleTypeExpression(parameterExp, "simple_type_entity1"))),
            parameterExp);
        }
        
        private static Expression CreateNewSimpleTypeExpression(ParameterExpression parameterExp, string simpleTypeProperty)
        {
            var simpleTypeExpr = (MemberInitExpression)SimpleType.CreateExpression().Body;
            MemberBinding[] bindings = new MemberBinding[simpleTypeExpr.Bindings.Count];
            for (int i = 0; i < bindings.Length; i++)
            {
                var oriBinding = simpleTypeExpr.Bindings[i];
                var memberName = ((MemberExpression)((MemberAssignment)oriBinding).Expression).Member.Name;
                bindings[i] = Expression.Bind(oriBinding.Member, Expression.Property(Expression.Property(parameterExp, simpleTypeProperty), memberName));
            }
            return Expression.MemberInit(simpleTypeExpr.NewExpression, bindings);
        }
    }
