    public string Document
      {
        get
        {
          return HttpUtility.HtmlEncode(txtDocument.Text);
        }
        set
        {
          txtDocument.Text = HttpUtility.HtmlEncode(value);
        }
      }
