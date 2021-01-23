    GridViewRow row = ((GridView)sender).FooterRow;
    TextBox txtName = (TextBox)row.FindControl("yourtextboxId");
    if (txtName == null)
    {
        return;
    }
    string name = txtName.Text;
