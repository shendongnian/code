    protected void InsertCard (object source, EventArgs e) {
        SqlDataSource1.Insert();
        ClearControls();
    }
    private void ClearControls()
    {
        foreach (Control c in Page.Controls)
        {
            foreach (Control ctrl in c.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
            }
        }
    }
