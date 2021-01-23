            WebBrowser wb = webBrowser1;
            var doc = wb.Document;
            HtmlElementCollection el = doc.GetElementsByTagName("input");
            foreach (HtmlElement btn in el)
            {
                if (btn.GetAttribute("value") == "Report")
                {
                    btn.InvokeMember("click");
                    break;
                }
            }
