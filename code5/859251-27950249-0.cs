    public interface IDescritible<T> where T : IDescritible<T>
	{
		Expression<Func<T, string>> DescriptionExpression { get; }
	}
	public class Foo : IDescritible<Foo>
	{
		public string Name { get; set; }
		public Expression<Func<Foo, string>> DescriptionExpression
		{
			get { return x => x.Name; }
		}
	}
	public abstract class AbstractSpecification<T>
	{
		public abstract Expression<Func<T, bool>> IsSatisfiedBy();
	}
	public class DescriptionMatch<T> : AbstractSpecification<T> 
		where T : IDescritible<T>, new()
	{
		public string Query { get; set; }
		public DescriptionMatch(string query)
		{
			this.Query = query;
		}
		public override Expression<Func<T, bool>> IsSatisfiedBy()
		{
			Expression<Func<T, string>> lambda = new T().DescriptionExpression;
			return Expression.Lambda<Func<T, bool>>(
				Expression.Call(
					lambda.Body,
					"Contains",
					Type.EmptyTypes,
					Expression.Constant(
						this.Query,
						typeof(string)
					)
				),
				lambda.Parameters
			);
		}
	}
	public class ExpressionReplacer : ExpressionVisitor
	{
		private readonly Expression _toBeReplaced;
		private readonly Expression _replacement;
		public ExpressionReplacer(Expression toBeReplaced, Expression replacement)
		{
			if (toBeReplaced.Type != replacement.Type)
			{
				throw new ArgumentException();
			}
			this._toBeReplaced = toBeReplaced;
			this._replacement = replacement;
		}
		public override Expression Visit(Expression node)
		{
			return Object.ReferenceEquals(node, this._toBeReplaced) ? this._replacement : base.Visit(node);
		}
	}
