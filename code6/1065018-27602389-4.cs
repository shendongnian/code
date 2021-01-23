    public class ComplexType
    {
        public Guid Id { get; set; }
        public SimpleType Property1 { get; set; }
        public SimpleType Property2 { get; set; }
        public static Expression<Func<complex_type_entity, ComplexType>> CreateExpression()
        {
            var expr = SimpleType.CreateExpression();
            return arg => new ComplexType
            {
                Id = arg.id,
                Property1 = expr.Compile()(arg.property1),
                Property2 = expr.Compile()(arg.property2)
            };
        }
    }
