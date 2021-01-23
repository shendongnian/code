     HtmlElementCollection inputHtmlCollection = Document.GetElementsByTagName("input");
     foreach (HtmlElement anInputElement in inputHtmlCollection)
    {
                        if (anInputElement.Name.Equals("portal_id"))
                        {
                            anInputElement.SetAttribute("VALUE", Properties.Settings.Default.sharepoint_user);
                        }
                        if (anInputElement.Name.Equals("password"))
                        {
                            anInputElement.SetAttribute("VALUE",  roperties.Settings.Default.sharepoint_pw);
                        }
    }
