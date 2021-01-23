    System.Text.StringBuilder result = new System.Text.StringBuilder();
    protected void cmdOK_Click(object sender, EventArgs e)
    {
        this.GetValues(this.phSchemaEMITenureDetails, this.result);
        this.litResult.Text = this.result.ToString();
    }
    private void GetValues(Control control, System.Text.StringBuilder strBuilder)
    {         
        if(control.HasControls())
        {
            foreach (Control item in control.Controls)
            {
	            if (item is TextBox)
                {
                    TextBox cntrl = (TextBox)item;
                    strBuilder.AppendLine(cntrl.ID.ToString() + " = " + cntrl.Text + "<br/>");
                }
                if (item.HasControls())
                {
                    this.GetValues(item, strBuilder);
                }
            }  
        }
    }
