    public async Task<string> GetMyData(string urlToCall)  {     
	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToCall);     
	request.Method = HttpMethod.Get;     
	HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();     
	using (var sr = new StreamReader(response.GetResponseStream()))      
	{         
 		return sr.ReadToEnd();      
	}  
}
