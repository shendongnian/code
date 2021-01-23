	public class CalculationPair<TEntityType, TProperty>
		where TEntityType : class
		where TProperty : struct
	{
		public ValueTypeProperty<TEntityType, TProperty> Left { get; set; }
		public Operand Operand { get; set; }
		public ValueTypeProperty<TEntityType, TProperty> Right { get; set; }
		public TResult Calculate<TResult>(TEntityType entity)
			where TResult : struct
		{
			TResult result = default(TResult);
			var prop = Expression.Parameter(typeof(TEntityType), "param");
			var visitor = new ParameterRewriter(prop);
			var leftExp = visitor.Visit(Left.PropertyExpression.Body);
			var rightExp = visitor.Visit(Right.PropertyExpression.Body);
			Expression body;
			switch (this.Operand.Type)
			{
				case OperandType.Multiplication:
					body = Expression.Multiply(leftExp, rightExp);
					break;
				case OperandType.Addition:
					body = Expression.Add(leftExp, rightExp);
					break;
				case OperandType.Division:
					body = Expression.Divide(leftExp, rightExp);
					break;
				case OperandType.Sunbtraction:
					body = Expression.Subtract(leftExp, rightExp);
					break;
				default:
					throw new Exception("Unknown operand type");
			}
			var lambda = Expression.Lambda<Func<TEntityType, TResult>>(body, prop);
			// compilation is long operation, so you might need to store this Func as property and don't compile it each time
			var func = lambda.Compile();
			result = func(entity);
			return (result);
		}
	}
