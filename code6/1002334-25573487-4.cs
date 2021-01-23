    async Task<string> DownloadLink(string linkID)
    {   
        string url = "http://sfshare.se/" + linkID;
        using (var clientHandler = new HttpClientHandler() { CookieContainer = new CookieContainer(), AllowAutoRedirect = false })
        {
            using (HttpClient client = new HttpClient(clientHandler))
            {
                //download html
                var html = await client.GetStringAsync(url).ConfigureAwait(false);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                //Wait 10 seconds
                await Task.Delay(1000 * 10).ConfigureAwait(false);
                var types = doc.DocumentNode.SelectNodes("//input[@type='hidden']")
                               .ToDictionary(i => i.Attributes["name"].Value, i => i.Attributes["value"].Value);
                types["referer"] = url;
                //Click :)
                var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(types) })
                                           .ConfigureAwait(false);
                var downloadUri = response.Headers.Location.ToString();
                var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.GetFileName(downloadUri));
                //Download
                using (var file = File.Create(fileName))
                {
                    var stream = await client.GetStreamAsync(downloadUri).ConfigureAwait(false); ;
                    await stream.CopyToAsync(file).ConfigureAwait(false); 
                }
                return fileName;
            }
        }
    }
