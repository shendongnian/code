    private void txtRegNazov_Enter(object sender, EventArgs e)
    {
        ClearFieldDataByEnter(sender);
    }
    
    private void txtRegNazov_Leave(object sender, EventArgs e)
    {
        FieldDataByleave(sender);
    }
        
    public void ClearFieldDataByEnter(object text) 
    { 
        textBox = text as TextBox;
        if (textbox == null)
           return;
        if (textbox.Text == "n/a")
        {
             textbox.Text = String.Empty;
        }
    }
    
    public void FieldDataByleave(object text) 
    {
        textBox = text as TextBox;
        if (textbox == null)
           return;
        if (String.IsNullOrEmpty(textbox.Text))
        {
           textbox.Text = "n/a";
        }
    }
