       public void ShowMessage(string htmlmsg)
       {
    	WebBrowser1.Navigate("");
    	while (WebBrowser1.ReadyState != WebBrowserReadyState.Complete) {
    		Application.DoEvents();
    		System.Threading.Thread.Sleep(1);
    	}
    	WebBrowser1.Document.Body.InnerHtml = htmlmsg;
       }
