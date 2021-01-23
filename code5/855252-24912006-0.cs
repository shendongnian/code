    private int maxReloadAttempt = 3;
		private int currentAttempt = 1;
		private string GetCarrier(string webAddress)
		{
			WebBrowser WebBrowser_4MobileCarrier = new WebBrowser();
			string innerHtml;
			string strStartSearchFor = "subtitle block pull-left\">";
			string strEndSearchFor = "<";
			try
			{
				WebBrowser_4MobileCarrier.ScriptErrorsSuppressed = true;
				WebBrowser_4MobileCarrier.Navigate(webAddress);	
				// MAKE SURE ReadyState = Complete
				while (WebBrowser_4MobileCarrier.ReadyState.ToString() != "Complete") {
					Application.DoEvents();			
				}
				// LOAD HTML
				innerHtml = WebBrowser_4MobileCarrier.Document.Body.InnerHtml;	
				// ATTEMPT (x3) TO EXTRACT CARRIER STRING
				while (currentAttempt <=  maxReloadAttempt) {
					if (innerHtml.IndexOf(strStartSearchFor) >= 0)
					{
						currentAttempt = 1;	// Reset attempt counter
						return Sub_String(innerHtml, strStartSearchFor, strEndSearchFor, "0"); // Method: "Sub_String" is my custom function
					}
					else
					{
						currentAttempt += 1;	// Increment attempt counter
						GetCarrier(webAddress);	// Recursive method call
					} // End if
				} // End while
			}	// End Try
			catch //(Exception ex)
			{
			}
			return "Unavailable";
		}
