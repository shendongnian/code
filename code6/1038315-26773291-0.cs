    void VisitBinaryExpression(BinaryExpressionSyntax binaryExpression)
    {
       var conversion = semanticModel.GetConversion(binaryExpression.Right);
       if (conversion.IsMethodGroup)
       {
           
       }
    }
