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
        //you marked the method Async, and
        //since Aya is in the class, if multiple threads call this
        //method, you could get inconsistent results
        //I have changed it to a parameter here so this doesn't happen
        StringBuilder Aya = new StringBuilder()
        Aya_ParseHtmlNode(htmlDocument.DocumentNode, Aya);
        //I would also move your textbox update here, so you aren't calling
        //ToString() all the time, wasting all of the memory benefits
        textBox1.Text = Aya.ToString();
    }
    int aia = 0;
    private void Aya_ParseHtmlNode(HtmlNode htmlNode, StringBuilder Aya)
    {
        foreach (HtmlNode childNode in htmlNode.ChildNodes)
        {
            if (childNode.NodeType == HtmlNodeType.Text && aia == 1)
            {
                Aya.Append(childNode.InnerText); aia = 0;
            }
            else if (childNode.NodeType == HtmlNodeType.Element)
            {
               Aya.Append(" ");
                switch (childNode.Name.ToLower())
                {
                    case "span":
                        Aya.Append(childNode.NextSibling.InnerText);
                       Aya_ParseHtmlNode(childNode, Aya);
                        break;
                    case "td":
                        aia = 1;
                        Aya_ParseHtmlNode(childNode, Aya);break;
                    default:
                        Aya_ParseHtmlNode(childNode, Aya); break;
                }
            }
        }
    }
