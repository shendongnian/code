	public static class ActionHelper<T> where T : Controller
	{
		...
		private static string GetParameter<U>(ParameterInfo info, U value)
		{
			var serializableValue = value as IUrlSerializable;
			if (serializableValue == null)
				return GetParameter(info.Name, value.ToString());
			return String.Join("&",
				serializableValue.GetQueryParams().Select(param => GetParameter(param.Key, param.Value)));
		}
		private static string GetParameter(string name, string value)
		{
			return name + '=' + Uri.EscapeDataString(value);
		}
	}
