	try
    {
       //Write HTTP output
		HttpContext.Current.Response.Write(Data);
	}  
    catch (Exception exc) {}
    finally {
	   try 
        {
          //stop processing the script and return the current result
		  HttpContext.Current.Response.End();
         } 
       catch (Exception ex) {} 
       finally {
			//Sends the response buffer
			HttpContext.Current.Response.Flush();
			// Prevents any other content from being sent to the browser
			HttpContext.Current.Response.SuppressContent = true;
			//Directs the thread to finish, bypassing additional processing
			HttpContext.Current.ApplicationInstance.CompleteRequest();
            //Suspends the current thread
		    Thread.Sleep(1);
	     }
       }
