    public async void Aya_Parse()
    {
        // Initialize http client.
        HttpClient httpClient = new HttpClient();
        Stream stream = await httpClient.GetStreamAsync("some link");
        // Load html document from stream provided by http client.
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.OptionFixNestedTags = true;
        htmlDocument.Load(stream);
        //  greetingOutput.Text = htmlDocument.DocumentNode.InnerText.ToString();
        // Parse html node, this is a recursive function which call itself until
        // all the childs of html document has been navigated and parsed.
        Aya_ParseHtmlNode(htmlDocument.DocumentNode);
    }
    int aia = 0;
    string Aya = null;
    private void Aya_ParseHtmlNode(HtmlNode htmlNode)
    {
        if (Aya == null)
        {
            Aya = String.empty;
        }
        foreach (HtmlNode childNode in htmlNode.ChildNodes)
        {
            if (childNode.NodeType == HtmlNodeType.Text && aia == 1)
            {
                Aya += " " + childNode.InnerText.ToString(); aia = 0;
            }
            else if (childNode.NodeType == HtmlNodeType.Element)
            {
               Aya += " ";
                switch (childNode.Name.ToLower())
                {
                    case "span":
                        Aya += childNode.NextSibling.InnerText.ToString();
                       Aya_ParseHtmlNode(childNode);
                        break;
                    case "td":
                        aia = 1;
                        Aya_ParseHtmlNode(childNode);break;
                    default:
                        Aya_ParseHtmlNode(childNode); break;
                }
            }
        }
        textBox1.Text = Aya;
    }
