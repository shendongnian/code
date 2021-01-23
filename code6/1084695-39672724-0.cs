    StringWriter sw = new StringWriter();
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    printableArea.RenderControl(hw); // Here printable area is nothing but div on aspx page with id and runaat="server" tag.
    
    StringReader sr = new StringReader(sw.ToString());
     string strHtml = sr.ReadToEnd();
     sr.Close();
