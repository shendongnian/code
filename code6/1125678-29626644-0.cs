       private void il_url_btn_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement item in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (item.GetAttribute("value").Equals(IlValuesList[sayac].Attributes["value"].Value))
                {
                    item.InvokeMember("click");
                    break;
                }
            }
            foreach (HtmlElement item in webBrowser1.Document.GetElementsByTagName("a"))
            {
                if (item.GetAttribute("id").Equals("btnSearch"))
                {
                    item.InvokeMember("click");
                    break;
                }
            }
            linkCek = true;
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (linkCek)
            {
                if (e.Url == webBrowser1.Url)
                {
                    if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        return;
                    else
                    {
                        string path = Application.StartupPath + "\\XMLDosyalari" + kategoriXml[0];
                        XDocument xdoc = XDocument.Load(path);
                        xdoc.Element("Hepsi").Add(new XElement(IlValuesList[sayac].Name, new XAttribute("class", "il"), new XAttribute("value", IlValuesList[sayac].Attributes["value"].Value), new XAttribute("url", webBrowser1.Url.ToString())));
                        xdoc.Save(path);
                        sayac++;
                        il_url_btn.PerformClick();
                    }
                }
                else { return; }
            }
            else { }
        }
