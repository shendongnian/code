	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	// note: you will have to include a reference to "System.Web.Extensions" in your project to be able to use this...
	using System.Web.Script.Serialization;
	namespace KeyValuePairTestApp
	{
		class Program
		{
			static void Main(string[] args)
			{
				List<KeyValuePair<string, string>> pair = new List<KeyValuePair<string, string>>()
				{
					new KeyValuePair<string, string>("MyFirstKey", "MyFirstValue"),
					new KeyValuePair<string, string>("MySecondKey", "MySecondValue")
				};
				string json = new JavaScriptSerializer().Serialize(pair);
				Console.WriteLine(json);
			}
		}
	}
