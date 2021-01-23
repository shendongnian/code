    protected void Page_PreRender(object sender, EventArgs e)
    {
            if (count == 3)
            {
                btn.Enabled = true;
            }
            else
            {
                btn.Enabled = false;
            }
    }
