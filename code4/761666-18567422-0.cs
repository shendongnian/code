     private void btnOK_Click(object sender, EventArgs e)
    {
        if(!Validate())
        {
            //Invalid
        }
        //Valid so set details
    }
    private bool Validate()
    {
         if (!string.IsNullOrEmpty(tbVendorName.Text))
         {
              MessageBox.Show(...);
            return false;
         }
    
        return true;
    }
