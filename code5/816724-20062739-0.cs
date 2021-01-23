	using System.Linq.Expressions;
	public static class ImplementClass
	{
		public static bool DoSomething<T>(Expression<Func<T>> propertyExpression)
		{
			var memberInfo = ((MemberExpression)propertyExpression.Body).Member;
			var declaringType = memberInfo.DeclaringType;
			Console.WriteLine(declaringType.Name); // outputs "MyClass"
			return false;
		}
	}
