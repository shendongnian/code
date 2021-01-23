    private void AfteDocumentLoads()
        {
            HtmlElementCollection textBox = webBrowser.Document.GetElementsByTagName("textarea").GetElementsByName("xhpc_message");
            HtmlElementCollection button = webBrowser.Document.GetElementsByTagName("button");
            foreach (HtmlElement element in textBox)
            {
                foreach (HtmlElement btnelement in button)
                {
                    if (btnelement.InnerText == "Post")
                    {
                        element.Focus();
                        element.InnerText = txtPortalUserId.Text.ToString();
                        btnelement.InvokeMember("Click");
                    }
                }
            }
        }
