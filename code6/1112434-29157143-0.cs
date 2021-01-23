	public static void PlumOutboundQueuecall(ObjectModel model)
	{
		// Create a request for the URL. 		
		WebRequest request = WebRequest.Create(Settings.IvrOutboundApi); //ease of editing/reusability //http://outbound.plumvoice.com/webservice/queuecall.php
		request.Method = "POST";
		//request.ContentType = "multipart/form-data"; //This is only if I choose to upload a [.csv] file of phone numbers
		request.ContentType = "application/x-www-form-urlencoded";
		// I used http://stackoverflow.com/questions/14702902/post-form-data-using-httpwebrequest as reference for proper encoding
		StringBuilder postData = new StringBuilder();
		postData.Append(HttpUtility.UrlEncode("login") + "=" +              HttpUtility.UrlEncode("<MY_EMAIL_FOR_PLUM>") + "&");
		postData.Append(HttpUtility.UrlEncode("pin") + "=" +                HttpUtility.UrlEncode("<MY_PIN_FOR_PLUM>") + "&");
		postData.Append(HttpUtility.UrlEncode("phone_number") + "=" +       HttpUtility.UrlEncode(model.PhoneNumber) + "&");
		postData.Append(HttpUtility.UrlEncode("start_url") + "=" +          HttpUtility.UrlEncode("<MY_vXML_AS_ASPX_PAGE_SHOWN_BELOW>") + "&"); //"http://ip_address/MY_ASPX_PAGE.aspx"
		postData.Append(HttpUtility.UrlEncode("call_parameters") + "=" +    HttpUtility.UrlEncode("<THE_PHONE_MESSAGE_TEXT_TO_BE_READ>") + "&"); //includes 'model' properties
		postData.Append(HttpUtility.UrlEncode("result_url") + "=" +         HttpUtility.UrlEncode("<MY_RESULT_URL_AS_ASMX_PAGE_SHOWN_BELOW>")); //"http://ip_address/MY_ASMX_PAGE.asmx/PlumOutboundCallback"
		
		ASCIIEncoding ascii = new ASCIIEncoding();
		byte[] postBytes = ascii.GetBytes(postData.ToString());
		// add post data to request
		Stream postStream = request.GetRequestStream();
		postStream.Write(postBytes, 0, postBytes.Length);
		postStream.Flush();
		postStream.Close();
		
		// Get response
		// Used Fiddler to deconstruct/reverse-engineer
		using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
		{
			StreamReader reader = new StreamReader(response.GetResponseStream()); // Get the response stream  
			string result = reader.ReadToEnd(); // Read the contents and return as a string  
			if (result.Contains("failed"))
			{
				// Whatever error handling you want to do if your "result_url" page throws an error. I used this extensively while testing the proper way to set this up
			}
		}
	}
	
