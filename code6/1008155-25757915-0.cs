    using System;
    using System.Net;
    using System.IO;
    
    namespace ConsoleApplication1 {
    	class Program {
    		static void Main(string[] args) {
    
    			var webAddr = "https://app.detrack.com/api/v1/deliveries/create.json";
    
    			var httpWebRequest = (HttpWebRequest) WebRequest.Create(webAddr);
    
    			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
    
    			httpWebRequest.Method = "POST";
    
    			string postData = "key=dab13cc0094620102d89f06c0e464b7de0782bb979258d3a&json={""date"":""2014-08-28""}";
    
    			byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
    			httpWebRequest.ContentLength = byteArray.Length;
    
    			using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    
    			{
    
    				streamWriter.Write(byteArray, 0, byteArray.Length);
    
    				streamWriter.Flush();
    
    			}
    
    			var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
    
    			using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    
    			{
    
    				var result = streamReader.ReadToEnd();
    
    				MessageBox.Show(result);
    
    			}
    		}
    	}
    }
