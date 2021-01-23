	using System;
	using System.Linq.Expressions;
						
	public class Program
	{
		public static void Main()
		{
			Expression<Func<Parent, int>> expression = s => s.Application.ID;
			var val = new CustomVisitor().ConvertToString(expression);
			
			Console.WriteLine("expression is " + val);
		}
	}
	public class CustomVisitor : ExpressionVisitor
	{
		private ParameterExpression _param;
		private Expression _body;
		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			_body = node.Body;
			return base.VisitLambda(node);
		}
		protected override Expression VisitParameter(ParameterExpression node)
		{
			_param = node;
			return node;
		}
		public string ConvertToString(Expression expression)
		{
			Visit(expression);
			var parameterLength = _param.Name.Length + 1; // cuts name plus dot
			return _body.ToString().Substring(parameterLength);
		}
	}
	
	public class Parent
	{
		public Application Application {get;set;}
	}
	public class Application
	{
		public int ID {get;set;}
	}
