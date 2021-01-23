    foreach (GeckoElement currentTag in tagsCollection)
            {
                if (currentTag.GetAttribute("class").Equals("class_name"))
                {
                     ((GeckoHtmlElement)currentTag).Click()
                }
                //delay some seconds to click next button...
            }
