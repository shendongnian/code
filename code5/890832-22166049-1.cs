	public class BaseABCModel
	{
		public string A { get; set; }
		public string B { get; set; }
		public string C { get; set; }
		public BaseABCModel(string a = null, string b = null, string c = null)
		{
			A = a;
			B = b;
			C = c;
		}
		public Dictionary<string, string> GetParameters()
		{
			return GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
           .ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => 
           (String) propertyInfo.GetValue(this));
		}
	}
    //Methods:
	public byte[] DoSomething(BaseABCModel model)
	{
		string query = GetQuery("doSomething", model.GetParameters())
	}
	public string GetQuery(string methodName, Dictionary<string, string> parameters)
	{
		string parameterString = parameters.Where(parameter => !String.IsNullOrEmpty(parameter.Value))
        .Aggregate(String.Empty, (current, parameter) => String.Format(
        String.IsNullOrEmpty(current) ? "{0}?{1}={2}" : "{0}&{1}={2}",
        current, parameter.Key, parameter.Value));
		return methodName + parameterString;
	}
