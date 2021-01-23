    // --------- your code
    string url = Request.QueryString["url"];
    WebClient web = new WebClient();
    web.Encoding = System.Text.Encoding.GetEncoding("utf-8");
    string html = web.DownloadString(url);
    // --------- parser code
    var parser = new HtmlParser();
    var document = parser.Parse(html);
    //Get the tag with CSS selectors
    var ultag = document.QuerySelector("ul.list-2");
    // Get the tag's html string
    var ultag_html = ultag.ToHtml();
