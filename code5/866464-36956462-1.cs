    public class MyVisitor<TSource> : QueryNodeVisitor<TSource>
        where TSource: class
    { 
        List<FilterValue> filterValueList = new List<FilterValue>();
        FilterValue current = new FilterValue();
        public override TSource Visit(BinaryOperatorNode nodeIn)
        {
            if(nodeIn.OperatorKind == Microsoft.Data.OData.Query.BinaryOperatorKind.And 
                || nodeIn.OperatorKind == Microsoft.Data.OData.Query.BinaryOperatorKind.Or)
            {
                current.LogicalOperator = nodeIn.OperatorKind.ToString();
            }
            else
            {
                current.ComparisonOperator = nodeIn.OperatorKind.ToString();
            }
            nodeIn.Right.Accept(this);
            nodeIn.Left.Accept(this);
            return current as TSource;
        }
        public override TSource Visit(SingleValuePropertyAccessNode nodeIn)
        {
            current.FieldName = nodeIn.Property.Name;
            //We are finished, add current to collection.
            filterValueList.Add(current);
            //Reset current
            current = new FilterValue();
            return current as TSource;
        }
        public override TSource Visit(ConstantNode nodeIn)
        {
            current.Value = nodeIn.LiteralText;
            return current as TSource;
        }
        
    }
