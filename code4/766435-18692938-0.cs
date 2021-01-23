    private void CheckAll(Control parent)
    {
        foreach(Control c in parent.Controls)
        {
            if (c is CheckBox)
                Check((CheckBox)c);
            
            CheckAll(c.Controls);
        }
    }
    private void CheckAll()
    {
        CheckAll(this);
    }
