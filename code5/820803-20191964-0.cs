           private string HtmlUpdateWithImage(string stringHtml)
            {
                System.Windows.Forms.WebBrowser browser = new System.Windows.Forms.WebBrowser();
                browser.Navigate("about:blank");
                HtmlDocument doc = browser.Document;
                doc.Write(stringHtml);
    
                if (null != browser.Document && null != browser.Document.Images && browser.Document.Images.Count > 0)
                {
                    // Here you can get the image list browser.Document.Images
                    foreach (System.Windows.Forms.HtmlElement item in browser.Document.Images)
                    {
                        // To get file path for each image
                        string imageFilePath = item.GetAttribute("src");
                        // Or either you can set those values
    
                        item.SetAttribute("src","testPath");
                    }
                }
                return "<HTML>" + browser.Document.Body.OuterHtml + "</HTML>";
            }
