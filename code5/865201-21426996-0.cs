    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       try
        {
            this.strValue = txtField.Text;
    
            if (this.LeavingFocus != null)
            {
                this.LeavingFocus(this.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
