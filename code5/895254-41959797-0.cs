			UIWebView webView = new UIWebView(View.Bounds);
			View.AddSubview(webView);
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var yourWonFolderPath = Path.Combine(documents, "YourWonFolder");
			var localDocUrl = Path.Combine(yourWonFolderPath, TicketInfo.TicketNumber + ".pdf");
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localDocUrl, false)));
			webView.ScalesPageToFit = true;
