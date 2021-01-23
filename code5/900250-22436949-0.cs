    tagsColl = webBrowser1.Document.GetElementsByTagName("button");
            foreach (HtmlElement curElement in tagsColl)
            {
                if (curElement.GetAttribute("submit").Equals(""))
                {
                    curElement.InvokeMember("click");
                }
            }
