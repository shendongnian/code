	public class ParameterRewriter : ExpressionVisitor
	{
		private readonly ParameterExpression _expToRewrite;
		public ParameterRewriter(ParameterExpression expToRewrite)
		{
			this._expToRewrite = expToRewrite;
		}
		protected override Expression VisitParameter(ParameterExpression node)
		{
			// we just use type checking to understand that it's our parameter, and we replace it with new one
			if (node.Type == this._expToRewrite.Type) return this._expToRewrite;
			return base.VisitParameter(node);
		}
	}
