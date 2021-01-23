    using System.Xml;
    using System.Xml.Linq;
    ...
			var xml = new XElement("div");
			
			foreach(var city in lst.GroupBy(x=>x.City))
			{
				var cityXml = new XElement("h2", city.Key);
				var cityUl = new XElement("ul");				
				foreach(var client in city.GroupBy(c=>c.ClientCode))
				{
					var clientXml = new XElement("li", client.Key);
					var clientUl = new XElement("ul");
					
					foreach(var num in client.GroupBy(cl=>cl.Num))
					{
						var numXml = new XElement("li", num.Key);
						var numUl = new XElement("ul");						
						foreach(var phone in num)
						{
							numUl.Add(new XElement("li",phone.Phone));
						}
						clientUl.Add(numXml);
						clientUl.Add(numUl);
					}					
					cityUl.Add(clientXml);
					cityUl.Add(clientUl);
				}
				xml.Add(cityXml);
				xml.Add(cityUl);
			}
			
			string res = xml.ToString();
