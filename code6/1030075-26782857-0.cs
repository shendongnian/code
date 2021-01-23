    public void cb1_OnTextUpdate(object sender, EventArgs e)
    {
        if(dataType == 1)
        {
           this.btnAction.Visible = !(cb1.Text == emp.FirstName)
        }
    }
