    string theFileHtml = System.IO.File.ReadAllText("c:\\test1.txt");
        WebBrowser1.Navigate("");
        while (WebBrowser1.ReadyState != WebBrowserReadyState.Complete) {
        	Application.DoEvents();
        	System.Threading.Thread.Sleep(1);
        }
        	//Also You Can Use WebBrowser1.DocumentText
        WebBrowser1.Document.Body.InnerHtml = theFileHtml;
