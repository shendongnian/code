    public void MinimizeAllChildForms(Form parent)
    {
        foreach(Form f in parent.OwnedForms)
        {
            f.WindowState = FormWindowState.Minimized;
            MinimizeAllChildForms(f);
        }
    }
