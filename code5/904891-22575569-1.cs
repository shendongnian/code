    newSpan = new Span();
    Run urlRun = new Run();
    urlRun.Text = urlMatches[i].Value;
    Hyperlink urlLink = new Hyperlink();
    urlLink.NavigateUri = new Uri(urlMatches[i].Value, UriKind.Absolute); // Add URI to the Hyperlink control
    urlLink.Click += urlLink_Click; // Add event handler to control
    urlLink.Command = new DummyCommand(); // Workaround for the Click not been triggered
    urlLink.Inlines.Add(urlRun); // Add text to Hyperlin
