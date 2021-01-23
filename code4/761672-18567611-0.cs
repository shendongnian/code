    bool valid = new [] { tbVendorName, rtbVendorAddress, tbVendorEmail, tbVendorWebsite }
                        .All(textBox => !string.IsNullOrEmpty(textBox.Text));
    if(valid) 
    {
        VendorName = tbVendorName.Text;          
        VendorAddress = rtbVendorAddress.Text;
        VendorEmail = tbVendorEmail.Text;
        VendorWebsite = tbVendorWebsite.Text;
    }
