                    HtmlElementCollection page = webBrowser1.Document.GetElementsByTagName("input");
                    foreach (HtmlElement element in page)
                    {
                        if (element.GetAttribute("value").Contains("Submit"))
                        {
                            element.InvokeMember("click");
                        }
                    }
