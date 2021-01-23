    private void DoItRecursive(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if(c is UserControl)
                DoItRecursive(c);
            else if (c is TextBox)
                c.Enabled = true;
        }
    }
