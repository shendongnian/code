	if (select.OrderBy != null && select.OrderBy.Count > 0) 
	{
		this.AppendNewLine(Indentation.Same);
		sb.Append("ORDER BY ");
		for (int i = 0, n = select.OrderBy.Count; i < n; i++) 
		{
			OrderExpression exp = select.OrderBy[i];
			if (i > 0) 
			{
				sb.Append(", ");
			}
			this.Visit(exp.Expression);
			if (exp.OrderType != OrderType.Ascending) 
			{
				sb.Append(" DESC");
			}
		}
	}
