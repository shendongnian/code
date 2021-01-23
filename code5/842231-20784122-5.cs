    public class FilterElementAttribute : Attribute
    {
        public ExpressionType ExpressionType { get; private set; }
        public FilterElementAttribute(ExpressionType expressionType)
        {
            ExpressionType = expressionType;
        }
    }
    public class PersonFilter : IFilter
    {
        [FilterElement(ExpressionType.Equal)]
        public string Name { get; set; }
        [FilterElement(ExpressionType.GreaterThanOrEqual)]
        public int? Age { get; set; }
        //...
    }
