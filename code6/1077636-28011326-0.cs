    using System.Collections.Generic;
	using System.Web.Script.Serialization;
	namespace loopy
	{
	  class Program
	  {
		static void Main(string[] args)
		{
		  var ser = new JavaScriptSerializer();
		  string websvcResult = CallWebService();
		  var keysAndCapacities = ser.Deserialize<List<ServiceResultClass>>(websvcResult);
		}
		public static string CallWebService()
		{
		  //Call web service here, this is just a mock of course.
		  return @"[
					{
						""Key"": ""products"",
						""Value"": {
							""m_MaxCapacity"": 2147483647,
							""Capacity"": 64,
							""m_StringValue"": ""<li>sample products or search results in products category</li>"",
							""m_currentThread"": 0
						}
					},
					{
						""Key"": ""news"",
						""Value"": {
							""m_MaxCapacity"": 2147483647,
							""Capacity"": 55,
							""m_StringValue"": ""<li class='noresult'>sample news or search results in news category</li>"",
							""m_currentThread"": 0
						}
					}
				]";
		}
	  }
	  public class ServiceResultClass
	  {
		public string Key { get; set; }
		public Capacities Value { get; set; }
	  }
	  public class Capacities
	  {
		public long m_MaxCapacity { get; set; }
		public string m_StringValue { get; set; }
	  }
	}
