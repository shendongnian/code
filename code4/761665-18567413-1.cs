    if (string.IsNullOrEmpty(tbVendorName.Text)) 
    {
        MessageBox.Show("Vendor name is required");
        return;
    }
    if (string.IsNullOrEmpty(rtbVendorAddress.Text)) 
    {
        MessageBox.Show("Vendor address is required");
        return;
    }
    if (string.IsNullOrEmpty(tbVendorEmail.Text)) 
    {
        MessageBox.Show("Vendor email is required");
        return;
    }
    if (string.IsNullOrEmpty(tbVendorWebsite.Text)) 
    {
        MessageBox.Show("Vendor Website Required");
        return;
    }
    VendorName = tbVendorName.Text;          
    VendorAddress = rtbVendorAddress.Text;
    VendorEmail = tbVendorEmail.Text;
    VendorWebsite = tbVendorWebsite.Text;
