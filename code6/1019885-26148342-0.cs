    HtmlElementCollection htmlcol = webBrowser1.Document.GetElementsByTagName("input");
    for (int i = 0; i < htmlcol.Count;  i++)
         {
         if (htmlcol[i].OuterHtml.Contains("Username"))
            {
               htmlcol[i].SetAttribute("value", pUsername.Text);
            }
    }
