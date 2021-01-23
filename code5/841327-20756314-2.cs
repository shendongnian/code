    GeckoNodeCollection nod = geckoWebBrowser1.Document.GetElementsByClassName("classname");
            foreach (GeckoNode node in nod)
            {
                if (NodeType.Element == node.NodeType)
                {
                                       
                    try
                    {
                        GeckoInputElement ele = (GeckoInputElement)node;
                        ele.Click();
                    }
                    catch (Exception ex)
                    {
                        string ep = ex.ToString();
                        GeckoHtmlElement ele = (GeckoHtmlElement)no2;
                        ele.Click();
                    }                    
                }
            }  
