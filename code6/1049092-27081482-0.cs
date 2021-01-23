            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://example.com/nodocument.html");
			req.Method = "GET";
			req.Timeout = 10000;
			req.KeepAlive = true;
			string content = null;
			HttpStatusCode code = HttpStatusCode.OK;
			try
			{
				using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
				{
					using (StreamReader sr = new StreamReader(response.GetResponseStream()))
						content = sr.ReadToEnd();
					code = response.StatusCode;
				}
			}
			catch (WebException ex)
			{
				using (HttpWebResponse response = (HttpWebResponse)ex.Response)
				{
					using (StreamReader sr = new StreamReader(response.GetResponseStream()))
						content = sr.ReadToEnd();
					code = response.StatusCode;
				}
			
			}
			//Here you have now content and code.
