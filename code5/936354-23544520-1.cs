    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            test1.Visible = false;
            test2.Visible = true;
            updDiv2.Update();
        }
    }
