            var inputs = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement input in inputs)
            {
                var id = input.Id;
                var name = input.Name;
                var val = input.OuterHtml;  // can parse value from here
            }
