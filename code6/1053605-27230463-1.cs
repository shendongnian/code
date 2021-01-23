        protected virtual void OnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            /* detach event handler */
            webCtrl.Navigated -= OnNavigated;
            /* check for all li's in document */
            HtmlElementCollection htmlElements = webCtrl.Document.GetElementsByTagName("li");
            if (htmlElements != null)
            {
                foreach (HtmlElement htmlElem in htmlElements)
                {
                    /* check if your li element contains the word Dossier protection */
                    if (htmlElem.InnerHtml.Contains("Dossier protection"))
                    {
                        /* if yes, get all url */
                        HtmlElementCollection urls = htmlElem.GetElementsByTagName("a");
                        if (urls == null || urls.Count == 0)
                        {
                            continue;
                        }
                        if (urls.Count == 1)
                        {
                            /* and simulate a click event */
                            urls[0].InvokeMember("click");
                            return;
                        }
                    }
                }
            }
        }
