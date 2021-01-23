    using System.IO;
    using System.Net;
    
    String url = "http://ifconfig.me/ip";
    String responseFromServer = null;
    try
    {
    	HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
    	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    	if (response.StatusCode == HttpStatusCode.OK)
    	{
    		using (Stream dataStream = response.GetResponseStream())
    		{
    			using (StreamReader reader = new StreamReader(dataStream))
    				responseFromServer = reader.ReadToEnd();
    		}
    	}
    }
    catch { }
    
    if (!String.IsNullOrEmpty(responseFromServer))
        MessageBox.Show(responseFromServer);
