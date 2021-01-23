    foreach (var c in X.Controls)
    {
       if (c is WebControl && ((WebControl)c).CssClass == "myClass")
          //Do something
       else if (c is HtmlControl && ((HtmlControl)c).Attributes.ContainsKey("class") && ((HtmlControl)c).Attributes["class"] == "myClass")
          //Do something
    
    }
