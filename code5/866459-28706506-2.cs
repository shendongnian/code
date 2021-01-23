    public void TryNodeValue(SingleValueNode node, IDictionary<string, object> values)
        {
            if (node is BinaryOperatorNode )
            {
                var bon = (BinaryOperatorNode)node;
                var left = bon.Left;
                var right = bon.Right;
                if (left is ConvertNode)
                {
                    var convLeft = ((ConvertNode)left).Source;
                    if (convLeft is SingleValuePropertyAccessNode && right is ConstantNode)
                        ProcessConvertNode((SingleValuePropertyAccessNode)convLeft, right, bon.OperatorKind, values);
                    else
                        TryNodeValue(((ConvertNode)left).Source, values);                    
                }
                if (left is BinaryOperatorNode)
                {
                    TryNodeValue(left, values);
                }
                if (right is BinaryOperatorNode)
                {
                    TryNodeValue(right, values);
                }
                if (right is ConvertNode)
                {
                    TryNodeValue(((ConvertNode)right).Source, values);                  
                }
                if (left is SingleValuePropertyAccessNode && right is ConstantNode)
                {
                    ProcessConvertNode((SingleValuePropertyAccessNode)left, right, bon.OperatorKind, values);
                }
            }
        }
        public void ProcessConvertNode(SingleValuePropertyAccessNode left, SingleValueNode right, BinaryOperatorKind opKind, IDictionary<string, object> values)
        {            
            if (left is SingleValuePropertyAccessNode && right is ConstantNode)
            {
                var p = (SingleValuePropertyAccessNode)left;
                if (opKind == BinaryOperatorKind.Equal)
                {
                    var value = ((ConstantNode)right).Value;
                    values.Add(p.Property.Name, value);
                }
            }
        }
