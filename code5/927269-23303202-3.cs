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
        sb.AppendLine("{");
        switch (e.ExpressionType)
        {
        case ExpressionType.And:
            sb.Append("\"Type\": \"And\",");
            break;
        ...
        }
        sb.Append("\"Left\":");
        VisitExpression(e.Left); sb.Append(",");
        sb.Append("\"Right\":");
        VisitExpression(e.Right);
        sb.AppendLine("}");
    }
