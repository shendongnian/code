           public Task<string> MakeAsyncRequest()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
              
                Task<WebResponse> task = Task.Factory.FromAsync(
                    request.BeginGetResponse,
                    asyncResult => request.EndGetResponse(asyncResult),
                    (object)null);
                return task.ContinueWith(t => ReadStreamFromResponse(t.Result));
            }
            private string ReadStreamFromResponse(WebResponse response)
            {
                string desc = "";
                try
                {
               using (Stream responseStream = response.GetResponseStream())
                    using (StreamReader sr = new StreamReader(responseStream))
                    {
                        //Need to return this response 
                        string strContent = sr.ReadToEnd();
                        HtmlDocument htmlDocument = new HtmlDocument();
                        htmlDocument.OptionFixNestedTags = true;
                        htmlDocument.LoadHtml(strContent);
                        HtmlAgilityPack.HtmlNode titleNode = htmlDocument.DocumentNode.SelectSingleNode("//meta[@property='og:description']");
                        if (titleNode != null)
                        {
                            desc = titleNode.GetAttributeValue("content", "");
                        }
                        imageDesc = desc;
                        return desc;
                    }
                }
                catch (Exception ex)
                { return desc; }
            }
            public string imageDesc { get; private set; }
        }
