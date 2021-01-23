    protected void btn_Click(object source, EventArgs e)
    {
        Button btn = (Button) sender;
        RepeaterItem item = (RepeaterItem) btn.NamingContainer;
        Button btnNewNumber0 = (Button)item.FindControl("btnNumer0");
        Button btnNewNumber1 = (Button)item.FindControl("btnNumer1");
        bool btn0Clicked = btn == btnNewNumber0;
        btnNewNumber0.Visible = !btn0Clicked;
        btnNewNumber1.Visible = btn0Clicked;
        // now call your webservice, you have all you need here
        Label lblName = (Label) item.FindControl("lblName"); 
        Label lblSurname = (Label) item.FindControl("lblSurname"); 
        Label lblNumber = (Label) item.FindControl("lblNumber"); 
        DropDownList ddlColor = (DropDownList) item.FindControl("ddlColor");
        // now call your webservice, you get the color-selection via ddlColor.SelectedValue
    }
