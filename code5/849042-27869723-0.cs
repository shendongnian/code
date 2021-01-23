       private void LoadingFinished(object sender, EventArgs args)
        {
            if (geckoWebBrowser1.Document != null && geckoWebBrowser1.Document.Body != null)
            {
                foreach (var anchor in geckoWebBrowser1.Document.GetElementsByTagName("a"))
                {
                    var targetAttributeValue = anchor.GetAttribute("target");
                    if (!String.IsNullOrEmpty(targetAttributeValue))
                    {
                        Debug.WriteLine(anchor.GetAttribute("href") as string + " changed href from " + targetAttributeValue as string + " to _self");
                        anchor.SetAttribute("target", "_self");
                    }
                }
            }
        }
