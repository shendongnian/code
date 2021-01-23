    public enum MyOperand
    {
        Greater, Less, Equal
    }
    public static class MyExtensions
    {
        public static ExpressionType ToExpressionType(this MyOperand operand)
        {
            switch (operand)
            {
                case MyOperand.Greater: return ExpressionType.GreaterThan;
                case MyOperand.Less: return ExpressionType.LessThan;
                case MyOperand.Equal: return ExpressionType.Equal;
                default: throw new NotSupportedException();
            }
        }
    }
