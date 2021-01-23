    public void InsertLink(RichEditBox control, string url) 
    {
      //Check some conditions - else property assignment crashes
      if (string.IsNullOrEmpty(url)) return; 
      if (string.IsNullOrEmpty(control.Document.Selection.Text)) return; 
      control.Document.Selection.Link = "\"" + url + "\"";
    }
    public void RemoveLink(RichEditBox control) 
    {
      //Can only set Link to empty string, if a link is assigned, 
      //else property assignment crashes
      if (string.IsNullOrEmpty(control.Document.Selection.Link)) return; 
      control.Document.Selection.Link = "";
    }
