	public class Program
	{
		static void Main(string[] args)
		{
			var parameters = new Dictionary<string, object>();
			parameters.Add("ProductMetalProductType", 1);
			parameters.Add("IsActive", true);
			parameters.Add("Name", "New cool product");
			var expr = GenerateExpression<Product>(parameters);
			Console.WriteLine("Result expression:");
			Console.WriteLine(expr.ToString());
		}
		private static Expression<Func<T, bool>> GenerateExpression<T>(Dictionary<string, object> properties)
		{
			var type = typeof(T);
			List<Expression> expressions = new List<Expression>();
			var parameter = Expression.Parameter(typeof(T), "x");
			foreach (var key in properties.Keys)
			{
				var val = properties[key];
				var property = type.GetProperty(key);
				var eqExpr = Expression.Equal(Expression.MakeMemberAccess(parameter, property), Expression.Constant(val));
				expressions.Add(eqExpr);
			}
			Expression final = expressions.First();
			foreach (var expression in expressions.Skip(1))
			{
				final = Expression.And(final, expression);
			}
			Expression<Func<T, bool>> predicate =
				(Expression<Func<T, bool>>) Expression.Lambda(final, parameter);
			return predicate;
		}
	}
	public class Product
	{
		public int ProductMetalProductType { get; set; }
		public bool IsActive { get; set; }
		public string Name { get; set; }
	}
