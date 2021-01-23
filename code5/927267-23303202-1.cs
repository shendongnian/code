    StringBuilder sb = new StringBuilder();
    void VisitExpression(Expression e)
    {
        switch (e.ExpressionType)
        {
        case ExpressionType.And:
            return VisitBinaryExpression(e As BinaryExpression);
        ...
        }
    }
    void VisitBinaryExpression(BinaryExpression e)
    {
        VisitExpression(e.Left);
        switch (e.ExpressionType)
        {
        case ExpressionType.And:
            sb.Append(" & ");
            break;
        ...
        }
        VisitExpression(e.Right);
    }
