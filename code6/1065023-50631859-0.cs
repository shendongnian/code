    public class ComplexModel
    {
        [EntityExpression(nameof(ComplexEntity.Id))]
        public Guid Id { get; set; }
    
        [EntityExpression(nameof(ComplexEntity.Property1), IsComplex = true)]
        public SimpleModel Property1 { get; set; }
    
        [EntityExpression(nameof(ComplexEntity.Property2), IsComplex = true)]
        public SimpleModel Property2 { get; set; }
    }
