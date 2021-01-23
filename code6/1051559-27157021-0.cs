		public static void DynamicUpdate(string hostname, string myip, string username, string password)
		{
			try
			{
				HttpWebRequest req =
					(HttpWebRequest)
						HttpWebRequest.Create("http://dynupdate.no-ip.com/nic/update?hostname=" + hostname + "&myip=" + myip);
				req.Host = "dynupdate.no-ip.com";
				req.Credentials = new NetworkCredential(username, password);
				req.UserAgent = "My awesome update Client/1.0 contact@email.com";
				req.Method = "GET";
				using (var res = (HttpWebResponse)req.GetResponse())
				{
					// Do something with the response accordingly to
					// http://www.noip.com/integrate/response
				}
			}
			catch
			{
			}
		}
:)
