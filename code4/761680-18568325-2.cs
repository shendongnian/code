    private void btnOK_Click(object sender, EventArgs e)
            {
                var box = Controls.OfType<TextBox>().Any(x => !Validate(x));
                if (!box)
                {
                    VendorName = tbVendorName.Text;
                    VendorAddress = rtbVendorAddress.Text;
                    VendorEmail = tbVendorEmail.Text;
                    VendorWebsite = tbVendorWebsite.Text;
                }
            }
    
             private bool Validate(TextBox box)
             {
                 if (!String.IsNullOrEmpty(box.Text)) return true;
                     MessageBox.Show(@"vender " + new List<string> {"name","email","website","address"}
                    .Single(x => box.Name.ToLower().Contains(x)) + @" is required!...");
               return false;
             }
