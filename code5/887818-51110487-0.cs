    public void PostXMLData(string serviceUrl, XDocument requestXML)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serviceUrl);
			req.Method = "POST";
			req.Host = "SOMETHING";
			req.ContentType = "text/xml; charset=utf-8";
			req.Headers.Add("SOAPAction", "SOMETHING");
			req.Accept = "text/xml";
			using (Stream stream = req.GetRequestStream())
			{
				requestXML.Save(stream);
			}
			using (WebResponse resp = req.GetResponse())
			{
				using (StreamReader rd = new StreamReader(resp.GetResponseStream()))
				{
					var result = rd.ReadToEnd();
					if (result.Contains("error"))
					{
						throw new Exception($"XML Submission Failed: {result}");
					}
				}
			}
		}
