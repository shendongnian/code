       HtmlAgilityPack.HtmlDocument document  =new  HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(HTML);
                    IEnumerable<HtmlNode> links = document.DocumentNode.Descendants("span");
                    foreach (var element in links)
                    {
                       string style = element.Attributes["style"].Value;
                       string[] styles=style.Split(';');
                       richTextBox1.Text += "\n" + styles[0].Replace("font-family:", "");
                       richTextBox1.Text += "\n" + styles[1].Replace("font-size:", "");
                       richTextBox1.Text += "\n" + styles[2].Replace("color:", "");
                    }
