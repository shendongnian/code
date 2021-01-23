    using System;
	using System.Net;
    using System.IO;
	using System.Text;
					
	public class Program
	{
		public static void Main()
		{
			string data = "";
            string s = "http://www.example.com";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(s);
			request.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X                       10_6_8) AppleWebKit/534.30 (KHTML, like Gecko) Chrome/12.0.742.122 Safari/534.30\"";
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{				
				if (response.StatusCode == HttpStatusCode.OK)
				{
					using (Stream receiveStream = response.GetResponseStream()) 
					{
						using (StreamReader readStream = new StreamReader(receiveStream))
						{						
							data = readStream.ReadToEnd();
							
						}
					}
				}
			}
			
			Console.WriteLine(data);
		}
	}
