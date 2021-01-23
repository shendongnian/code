	try {
		HttpContext.Current.Response.Write(Data);
		HttpContext.Current.Response.End();
	} catch (System.Threading.ThreadAbortException exc) {
		try {
			//Sends the response buffer
			HttpContext.Current.Response.Flush();
			// Prevents any other content from being sent to the browser
			HttpContext.Current.Response.SuppressContent = true;
			//Directs the thread to finish, bypassing additional processing
			HttpContext.Current.ApplicationInstance.CompleteRequest();
		} catch (Exception ex) {
                  //Log Exception
		}
	}
