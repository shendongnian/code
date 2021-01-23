    protected void ProductsFormView_ModeChanged(Object sender, FormViewModeEventArgs e)
    {
        if(ProductsFormView.CurrentMode == FormViewMode.Edit)
        {
            Label lblSubmit = (Label)ProductsFormView.FindControl("lblSubmit");
            lblSubmit.Text = "Hi!";
        }
    }
