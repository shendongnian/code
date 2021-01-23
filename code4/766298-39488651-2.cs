     elements = webBrowser.Document.GetElementsByTagName("input");
            foreach (HtmlElement file in elements)
            {
                if (file.GetAttribute("name") == "file")
                {
                    SelectFile();
                    file.InvokeMember("Click");
                }
            }
