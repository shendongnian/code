	public static class ActionHelper<T> where T : Controller
	{
		public static string GetUrl(Expression<Func<T, Func<ActionResult>>> action)
		{
			return GetControllerName() + '/' + GetActionMethod(action).Name;
		}
		public static string GetUrl<U>(Expression<Func<T, Func<U, ActionResult>>> action, U param)
		{
			var method = GetActionMethod(action);
			var parameters = method.GetParameters();
			return $"{GetControllerName()}/{method.Name}?{parameters[0].Name}={param}";
		}
		public static string GetUrl<U1, U2>(
			Expression<Func<T, Func<U1, U2, ActionResult>>> action, U1 param1, U2 param2)
		{
			var method = GetActionMethod(action);
			var parameters = method.GetParameters();
			return $"{GetControllerName()}/{method.Name}?{parameters[0].Name}={param1}&{parameters[1].Name}={param2}";
		}
		private static string GetControllerName()
		{
			const string SUFFIX = nameof(Controller);
			string name = typeof(T).Name;
			return name.EndsWith(SUFFIX) ? name.Substring(0, name.Length - SUFFIX.Length) : name;
		}
		private static MethodInfo GetActionMethod(LambdaExpression expression)
		{
			var unaryExpr = (UnaryExpression)expression.Body;
			var methodCallExpr = (MethodCallExpression)unaryExpr.Operand;
			var methodCallObject = (ConstantExpression)methodCallExpr.Object;
			return (MethodInfo)methodCallObject.Value;
		}
	}
