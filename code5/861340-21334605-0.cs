    HtmlElementCollection links = _webB.Document.GetElementsByTagName("a");
                foreach (HtmlElement link in links)
                {
                    if (link.OuterHtml.ToString().Contains("unit_input_axe"))
                        link.InvokeMember("click");
                }
