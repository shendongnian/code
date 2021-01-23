    public static void SetControlText(string controlID, string text) 
    { 
       Page page = HttpContext.Current.Handler as Page;
       if (page != null)
       {
          Control ctrl = FindControlRecursive(page, controlID);
          if(ctrl != null)
          {
              ITextControl txt = ctrl as ITextControl;
              if(txt != null)
                  txt.Text = text;
          }
       }
    }
    
    public static Control FindControlRecursive(Control root, string id)
    {
        if (root.ID == id) return root;
        foreach (Control c in root.Controls)
        {
            Control t = FindControlRecursive(c, id);
            if (t != null) return t;
        }
        return null;
    }
