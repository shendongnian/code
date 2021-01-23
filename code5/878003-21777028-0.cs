    public class ReplacementVisitor : System.Linq.Expressions.ExpressionVisitor
	{
		private readonly Expression _oldExpr;
		private readonly Expression _newExpr;
		public ReplacementVisitor(Expression oldExpr, Expression newExpr)
		{
			_oldExpr = oldExpr;
			_newExpr = newExpr;
		}
	
		public override Expression Visit(Expression node)
		{
			if (node == _oldExpr)
				return _newExpr;
			return base.Visit(node);
		}
	}
