    protected void addrow_Click(object sender, EventArgs e)
    {
        Panel pnlEmployeeBox = new Panel();
        pnlEmployeeBox.CssClass = "pnlEmployeeBox";
    
        HtmlGenericControl columnLeft2= new HtmlGenericControl("div");
    columnLeft2.CssClass = "column-left2";
            TextBox txt1 = new TextBox();
    columnLeft2.Controls.Add(txt1);
    
    pnlEmployeeBox.Controls.Add(columnLeft2);
    
     columnLeft2 = new HtmlGenericControl("div");
    
            txt1 = new TextBox();
    
        pnlEmployeeBox.Controls.Add(columnLeft2);
    
    // and same goes for the dropdown list
    
    
    }
