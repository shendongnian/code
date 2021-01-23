    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      // Select checkboxes containing the word "this" (Select this email)
      foreach (HtmlElement oCheckBox in webBrowser1.Document.GetElementsByTagName("input"))
      {
        if (oCheckBox.GetAttribute("type").ToLower() == "checkbox")
        {
          if (oCheckBox.OuterHtml.ToLower().Contains("this"))
          {
            oCheckBox.SetAttribute("checked", "true");
          }
        }
      }
    }
