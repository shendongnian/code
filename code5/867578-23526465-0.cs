	foreach (GeckoIFrameElement _E in geckoWebBrowser1.Document.GetElementsByTagName("iframe"))
	{
		if (_E.GetAttribute("class") == "testClass")
		{
			var innerHTML = _E.ContentDocument;
			foreach (GeckoHtmlElement _A in innerHTML.GetElementsByTagName("input"))
			{
				_A.SetAttribute("value", "Test");
			}
		}
	}
