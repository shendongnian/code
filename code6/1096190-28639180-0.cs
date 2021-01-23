    private void DeleteBoxes()
    {
        List<Control> toDispose = new List<Control>();
        foreach (Control c in this.Controls)
        {
            if (c is CheckBox && c.Tag.ToString() == "TOOL" )
                toDispose.Add(c);
        }
        foreach (Control c in toDispose)
        {
            c.Dispose();
        }
    }
