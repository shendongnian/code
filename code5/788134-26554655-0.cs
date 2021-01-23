    	using System.IO;
		using System.Net;
		public string GetUserIP()
		{
			string strIP = String.Empty;
			HttpRequest httpReq = HttpContext.Current.Request;
			//test for non-standard proxy server designations of client's IP
			if (httpReq.ServerVariables["HTTP_CLIENT_IP"] != null)
			{
				strIP = httpReq.ServerVariables["HTTP_CLIENT_IP"].ToString();
			}
			else if (httpReq.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
			{
				strIP = httpReq.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
			}
			//test for host address reported by the server
			else if
			(
				//if exists
				(httpReq.UserHostAddress.Length != 0)
				&&
				//and if not localhost IPV6 or localhost name
				((httpReq.UserHostAddress != "::1") || (httpReq.UserHostAddress != "localhost"))
			)
			{
				strIP = httpReq.UserHostAddress;
			}
			//finally, if all else fails, get the IP from a web scrape of another server
			else
			{
				WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
				using (WebResponse response = request.GetResponse())
				using (StreamReader sr = new StreamReader(response.GetResponseStream()))
				{
					strIP = sr.ReadToEnd();
				}
				//scrape ip from the html
				int i1 = strIP.IndexOf("Address: ") + 9;
				int i2 = strIP.LastIndexOf("</body>");
				strIP = strIP.Substring(i1, i2 - i1);
			}
			return strIP;
		}
