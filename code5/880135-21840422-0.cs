    private void CreateControl<T>(string objText, Panel pnl, string HTMLTag,
        string applicantID, EventHandler hndl) 
        where T : new() // allows to create an instance, no need for reflection
    {
        pnl.Controls.Add(new LiteralControl(HTMLTag));
        T obj = new T();
        if (obj is IButtonControl) (obj as IButtonControl).Text = objText;
        if (obj is ITextControl) (obj as ITextControl).Text = objText;
        if (applicantID != string.Empty)
        {   
            if (obj is WebControl)
                (obj as WebControl).Attributes.Add("ApplicantID", applicantID);
        }
        if (hndl != null)
        {
            if (obj is IButtonControl)
                (obj as IButtonControl).Click += new EventHandler(hndl);
        }
        pnl.Controls.Add(obj as Control);
        pnl.Controls.Add(new LiteralControl(HTMLTag.Insert(1, "/")));
    }
