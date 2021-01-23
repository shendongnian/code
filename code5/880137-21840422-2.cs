    private void CreateControl<T>(string objText, Panel pnl, string HTMLTag, 
        string applicantID, EventHandler hndl)
            where T : Control, new()
    {
        pnl.Controls.Add(new LiteralControl(HTMLTag));
        T obj = new T();
        if (obj is ITextControl) (obj as ITextControl).Text = objText;
        
        if (applicantID != string.Empty && obj is WebControl)
            (obj as WebControl).Attributes.Add("ApplicantID", applicantID);
        
        
        if (obj is IButtonControl)
        {
            (obj as IButtonControl).Text = objText;
            if (hndl != null)
            {
                (obj as IButtonControl).Click += new EventHandler(hndl);
            }
        }
        pnl.Controls.Add(obj as Control);
        pnl.Controls.Add(new LiteralControl(HTMLTag.Insert(1, "/")));
    }
