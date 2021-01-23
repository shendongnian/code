    private void btnOK_Click(object sender, EventArgs e)
    {
	    
       if (!string.IsNullOrEmpty(tbVendorEmail.Text))
           {
              VendorEmail = tbVendorEmail.Text;
                    
           }
           else
           {
               MessageBox.Show("Vendor email is required");
           }
        if (!string.IsNullOrEmpty(tbVendorName.Text))
        {
            VendorName = tbVendorName.Text;
            
        }
        else
        {
            MessageBox.Show("Vendor name is required");
        }
        if (!string.IsNullOrEmpty(rtbVendorAddress.Text))
        {
            VendorAddress = rtbVendorAddress.Text;
                
        }
        else
        {
            MessageBox.Show("Vendor address is required");
        }
        if (!string.IsNullOrEmpty(tbVendorWebsite.Text))
            {
               VendorWebsite = tbVendorWebsite.Text;
               this.Close();
            }
            else
            {
            MessageBox.Show("Vendor Website Required");
            }
    }
