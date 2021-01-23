    private int Total
    {
        get
        {
            int total;
            if (Int32.TryParse(ddlUserSelected.SelectedItem.Text, out total)) 
                return total;
            return 0;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateTextBoxes(Total);
    }
    
    protected void ddlUserSelected_SelectedIndexChanged(object sender, EventArgs e)
    {
        CreateTextBoxes(Total);
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int total = Total;
        for (int a = 1; a <= total; a++)
        {
            var textbox = PlaceHolder1.FindControl("txtDate" + a) as TextBox;
        }
    }
    
    private void CreateTextBoxes(int total)
    {
        for (int a = 1; a <= total; a++)
        {
            // Make sure we do not add same ID again
            if (PlaceHolder1.FindControl("txtDate" + a) == null)
            {
                TextBox txtDate = new TextBox();
                Label lbl = new Label();
                lbl.Text = "<br/>";
                txtDate.Width = 70;
                txtDate.CssClass = "tbl";
                txtDate.ID = "txtDate" + a;
                PlaceHolder1.Controls.Add(txtDate);
                PlaceHolder1.Controls.Add(lbl);
            }
        }
    }
