	internal class Program
	{
		private static void Main(string[] args)
		{
			var stream = new MemoryStream();
			using (stream)
			{
				using (var workbook = new XLWorkbook())
				{
					using (var worksheet = Proxy(workbook.Worksheets.Add("Sheet 1")))
					{
						worksheet.Cell("A1").Value = "This  is a test";
						worksheet.Cell("A2").Value = "This \v is a test";
						workbook.SaveAs(stream);
					}
				}
			}
		}
		public static IXLWorksheet Proxy(IXLWorksheet target)
		{
			var generator = new ProxyGenerator();
			var options = new ProxyGenerationOptions { Selector = new WorksheetInterceptorSelector() };
			return generator.CreateInterfaceProxyWithTarget<IXLWorksheet>(target, options);
		}
	}
	public class WorksheetInterceptorSelector : IInterceptorSelector
	{
		private static readonly MethodInfo[] methodsToAdjust;
		private readonly ProxyCellInterceptor proxyCellInterceptor = new ProxyCellInterceptor();
		static WorksheetInterceptorSelector()
		{
			methodsToAdjust = typeof(IXLWorksheet).GetMethods()
				.Where(x => x.Name == "Cell")
				.Union(new[] { typeof(IXLWorksheet).GetProperty("ActiveCell").GetGetMethod() })
				.ToArray();
		}
		#region IInterceptorSelector Members
		public IInterceptor[] SelectInterceptors(System.Type type, System.Reflection.MethodInfo method, IInterceptor[] interceptors)
		{
			if (!methodsToAdjust.Contains(method))
				return interceptors;
			return new IInterceptor[] { proxyCellInterceptor }.Union(interceptors).ToArray();
		}
		#endregion
	}
	public class CellInterceptorSelector : IInterceptorSelector
	{
		private static readonly MethodInfo[] methodsToAdjust = new[] { typeof(IXLCell).GetMethod("SetValue"), typeof(IXLCell).GetProperty("Value").GetSetMethod() };
		private ValidateMethodInterceptor proxyCellInterceptor = new ValidateMethodInterceptor();
		#region IInterceptorSelector Members
		public IInterceptor[] SelectInterceptors(System.Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			if (method.IsGenericMethod && method.Name == "SetValue" || methodsToAdjust.Contains(method))
                return new IInterceptor[] { proxyCellInterceptor }.Union(interceptors).ToArray();
            return interceptors;
		}
		#endregion
	}
	public class ProxyCellInterceptor : IInterceptor
	{
		#region IInterceptor Members
		public void Intercept(IInvocation invocation)
		{
			invocation.Proceed();
			//Wrap the return value
			invocation.ReturnValue = Proxy((IXLCell)invocation.ReturnValue);
		}
		#endregion
		public IXLCell Proxy(IXLCell target)
		{
			var generator = new ProxyGenerator();
			var options = new ProxyGenerationOptions { Selector = new CellInterceptorSelector() };
			return generator.CreateInterfaceProxyWithTarget<IXLCell>(target, options);
		}
	}
	public class ValidateMethodInterceptor : IInterceptor
	{
		#region IInterceptor Members
		public void Intercept(IInvocation invocation)
		{
			var value = invocation.Arguments[0];
			//Validate the data as it is being set
			if (value != null && value.ToString().Contains('\v'))
			{
				throw new ArgumentException("Value cannot contain vertical tabs!");
			}
			
			//Alternatively, you could do a string replace:
            //if (value != null && value.ToString().Contains('\v'))
            //{
            //    invocation.Arguments[0] = value.ToString().Replace("\v", Environment.NewLine);
            //}
			invocation.Proceed();
		}
		#endregion
	}
