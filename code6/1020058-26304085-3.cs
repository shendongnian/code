    public string HttpPostRequest(string url, Dictionary<string,string> postParameters)
    		{
    			url = "http://Mydomain:3000/" + url;
    			string postData = "";
    			foreach (string key in postParameters.Keys)
    			{
    				postData += HttpUtility.UrlEncode(key) + "="
    					+ HttpUtility.UrlEncode(postParameters[key]) + "&";
    			}
    
    			HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
    			myHttpWebRequest.Method = "POST";
    			byte[] data = System.Text.Encoding.ASCII.GetBytes(postData);
    			myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
    			myHttpWebRequest.ContentLength = data.Length;
    			Stream requestStream = myHttpWebRequest.GetRequestStream();
    			requestStream.Write(data, 0, data.Length);
    			requestStream.Close();
    			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
    			Stream responseStream = myHttpWebResponse.GetResponseStream();
    			StreamReader myStreamReader = new StreamReader(responseStream, System.Text.Encoding.Default);
    			string pageContent = myStreamReader.ReadToEnd();
    			myStreamReader.Close();
    			responseStream.Close();
    			myHttpWebResponse.Close();
    			return pageContent;
    		}
    
    		public string HttpGetRequest(string Url)
    		{
    			string Out = String.Empty;
    			Url = "http://Mydomain:3000/" + Url;
    			System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
    			try
    			{
    				System.Net.WebResponse resp = req.GetResponse();
    				using (System.IO.Stream stream = resp.GetResponseStream())
    				{
    					using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
    					{
    						Out = sr.ReadToEnd();
    						sr.Close();
    					}
    				}
    			}
    			catch (ArgumentException ex)
    			{
    				Out = string.Format("HTTP_ERROR :: The second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close' :: {0}", ex.Message);
    			}
    			catch (WebException ex)
    			{
    				Out = string.Format("HTTP_ERROR :: WebException raised! :: {0}", ex.Message);
    			}
    			catch (Exception ex)
    			{
    				Out = string.Format("HTTP_ERROR :: Exception raised! :: {0}", ex.Message);
    			}
    
    			return Out;
    		}
