	public static class ActionHelper<T> where T : Controller
	{
		public static string GetUrl(Expression<Func<T, Func<ActionResult>>> action)
		{
			return GetControllerName() + '/' + GetActionName(GetActionMethod(action));
		}
		public static string GetUrl<U>(
			Expression<Func<T, Func<U, ActionResult>>> action, U param)
		{
			var method = GetActionMethod(action);
			var parameters = method.GetParameters();
			return $@"{GetControllerName()}/{GetActionName(method)
				}?{GetParameter(parameters[0], param)}";
		}
		public static string GetUrl<U1, U2>(
			Expression<Func<T, Func<U1, U2, ActionResult>>> action, U1 param1, U2 param2)
		{
			var method = GetActionMethod(action);
			var parameters = method.GetParameters();
			return $@"{GetControllerName()}/{GetActionName(method)
				}?{GetParameter(parameters[0], param1)}&{GetParameter(parameters[1], param2)}";
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
			var method = (MethodInfo)methodCallObject.Value;
			Debug.Assert(method.IsPublic);
			return method;
		}
		private static string GetActionName(MethodInfo info)
		{
			return info.Name;
		}
		private static string GetParameter<U>(ParameterInfo info, U value)
		{
			return info.Name + '=' + Uri.EscapeDataString(value.ToString());
		}
	}
