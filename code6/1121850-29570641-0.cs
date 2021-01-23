    private void FindCookie ()
    		{
    			HttpWebRequest request = WebRequest.Create (addyourURL) as HttpWebRequest;
    			request.CookieContainer = new CookieContainer ();    
    			// Set the Method property of the request to POST.
    			request.Method = "POST";
    			// Create POST data and convert it to a byte array.
    			string postData = "loginForm=loginForm&j_username=admin&j_password=admin";
    			byte[] byteArray = Encoding.UTF8.GetBytes (postData);
    			// Set the ContentType property of the WebRequest.
    			request.ContentType = "application/x-www-form-urlencoded";
    			// Set the ContentLength property of the WebRequest.
    			request.ContentLength = byteArray.Length;
    			// Get the request stream.
    			Stream dataStream = request.GetRequestStream ();
    			// Write the data to the request stream.
    			dataStream.Write (byteArray, 0, byteArray.Length);
    			// Close the Stream object.
    			dataStream.Close ();
    			// Get the response.
    			HttpWebResponse response = request.GetResponse () as HttpWebResponse;
    			// Display the status.
    			Console.WriteLine (((HttpWebResponse)response).StatusDescription);
    			// Get the stream containing content returned by the server.
    			dataStream = response.GetResponseStream ();
    			// Open the stream using a StreamReader for easy access.
    			StreamReader reader = new StreamReader (dataStream);
    			// Read the content.
    			string responseFromServer = reader.ReadToEnd ();
    			// Display the content.
    			Console.WriteLine (responseFromServer);
    			// Clean up the streams.
    			reader.Close ();
    			dataStream.Close ();
    			response.Close ();
    
    			string sid = response.Cookies["JSESSIONID"].ToString();
    
    			Console.WriteLine(sid);
    }
