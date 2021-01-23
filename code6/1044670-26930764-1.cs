    	void Main()
        {				
            Foo(x => x.Name, x => x.Id, x => x.Address);
        }
 
        void Foo(params Expression<Func<Bar, object>>[] lambdas)
		{
            foreach (var lambda in lambdas)
            {
                ExpressionToString(lambda).Dump();
            }
        }
 
		public static string ExpressionToString(Expression selector)
		{
			string left, right, result;
			switch (selector.NodeType)
			{
				case ExpressionType.MemberAccess:
					var memberExpression = selector as MemberExpression;
					right = (memberExpression.Member as PropertyInfo).Name;
					if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
					{
						left = ExpressionToString(memberExpression.Expression);
						result = left + right;
					}
					else
					{
						result = right;
					}
					break;
				case ExpressionType.Call:
					var method = selector as MethodCallExpression;
					left = ExpressionToString(method.Arguments[0]);
					right = ExpressionToString(method.Arguments[1]);
					result = left + right;
					break;
				case ExpressionType.Lambda:
					var lambda = selector as LambdaExpression;
					result = ExpressionToString(lambda.Body);
					break;
				case ExpressionType.Quote:
				case ExpressionType.Convert:
					var unary = selector as UnaryExpression;
					result = ExpressionToString(unary.Operand);
					break;
				default:
					throw new InvalidOperationException("Expression must be MemberAccess, Call, Quote, Convert or Lambda");
			}
			return result;
		}
		
		public class Bar
		{
			public String Name { get; set; }
		
			public String Id { get; set; }
			
			public String Address { get; set; }
		}
