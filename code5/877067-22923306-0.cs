    /// the _profileQueue was a queue of URLs i wanted to nav through and find an 
    /// form elem and "click" the submit button on
    private async void Next()
        {
            Submission res = null;
            if (_profileQueue.TryDequeue(out res))
            {
                // dirty, but hold the details of the url i'm navigating to in the Tag
                _browser.Tag = res;
                var cts = new CancellationTokenSource(Properties.Settings.Default.BrowserNavigationTimeout); // cancel in 10s
                var html = await LoadDynamicPage(res.SiteProfile.URL, cts.Token);
                // this parses the dom once loaded (awaits for the page)
                ProcessSiteProfile();
                Next();
            }
        }
        // navigate and download 
        async Task<string> LoadDynamicPage(string url, CancellationToken token)
        {
            // navigate and await DocumentCompleted
            var tcs = new TaskCompletionSource<bool>();
            WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
                tcs.TrySetResult(true);
            // i'm keeping the tcs in a concurrentdictionary against the browser object
            // again, this is pretty dirty but obviously felt like i needed it.
            _browserTasks[_browser] = tcs;
            using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
            {
                // nav to page async
                this._browser.DocumentCompleted += handler;
                try
                {
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        this._browser.Navigate(url);                 
                        await tcs.Task; // wait for DocumentCompleted
                    }
                }
                finally
                {
                    this._browser.DocumentCompleted -= handler;
                }
            }
            // get the root element
            var documentElement = this._browser.Document.GetElementsByTagName("html")[0];
            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(Properties.Settings.Default.BrowserNavigationWait, token);
                // continue polling if the WebBrowser is still busy
                if (this._browser.IsBusy)
                    continue;
                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop
                html = htmlNow;
            }
            // consider the page fully rendered 
            token.ThrowIfCancellationRequested();
            
            // remove from task dictionary
            _browserTasks[this._browser] = null;
            return html;
        }
        async void ProcessSiteProfile()
        {
            // now process submission  
            HtmlElement parentForm = null;
            /////////////////
            // parse dom to find the form you're looking for 
            // couple of helpers below
            ///////////////////////
            parentForm = HtmlElementQuery(_browser.Document, "myTextFieldInput");
            var sub = (_browser.Tag as Submission);
            HtmlDocument doc = _browser.Document;
          
            if (parentForm != null)
            {               
                var elements = parentForm.GetElementsByTagName("input");
                foreach (HtmlElement el in elements)
                {
                    // If there's more than one button, you can check the
                    // element.InnerHTML to see if it's the one you want
                    if (el.GetAttribute("type").ToLower() == "submit")
                    {
                        var cts = new CancellationTokenSource(Properties.Settings.Default.BrowserNavigationTimeout); // cancel in 10s
                        var html = await RaiseDynamicEvent(el, "click", cts.Token);
                    }
                }
            }
        }
          // used to raise an event with a dom element that would cause the document to change 
        async Task<string> RaiseDynamicEvent(HtmlElement element, string evt, CancellationToken token)
        {
            // navigate and await DocumentCompleted
            var tcs = new TaskCompletionSource<bool>();
            WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
                tcs.TrySetResult(true);
            _browserTasks[_browser] = tcs;
            using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
            {
                this._browser.DocumentCompleted += handler;
               
                try
                {
                    element.InvokeMember(evt);
                    try
                    {
                        await tcs.Task; // wait for DocumentCompleted
                    }
                    catch (TaskCanceledException)
                    {
                        // no the end of the world
                        
                    }
                }
                finally
                {
                    this._browser.DocumentCompleted -= handler;
                }
            }
            // get the root element
            var documentElement = this._browser.Document.GetElementsByTagName("html")[0];
            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(500, token);
                // continue polling if the WebBrowser is still busy
                if (this._browser.IsBusy)
                    continue;
                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop
                html = htmlNow;
            }
            // consider the page fully rendered 
            token.ThrowIfCancellationRequested();
            // remove from task dictionary
            _browserTasks[this._browser] = null;
            return html;
        }
        // couple of useful helpers
        HtmlElement FindParentByElement(string elementName, HtmlElement element)
        {
            if (element.Parent != null)
            {
                if (element.Parent.TagName.ToLower() == elementName.ToLower())
                {
                    return element.Parent;
                }
                else
                {
                    return FindParentByElement(elementName, element.Parent);
                }
            }
            else
            {
                return null;
            }
        }
        HtmlElement HtmlElementQuery(HtmlDocument container, string query)
        {
            HtmlElement el = null;
            if (query.StartsWith("#"))
            {
                el = container.GetElementById(query.TrimStart('#'));
            }
            else
            {
                el = container.All[query];
            }
            return el;
        }
