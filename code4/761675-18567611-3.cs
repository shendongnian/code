    // Instantiating the specification.
    ISpecification<TextBox> textBoxSpec = new TextBoxSpecification();
    // Now, instead of just checking if it's not null or empty, the .All(...)
    // extension method will execute the specification for all text boxes
    bool valid = new [] { tbVendorName, rtbVendorAddress, tbVendorEmail, tbVendorWebsite }
                        .All(textBox => textBoxSpec.IsSatisfiedBy(textBox));
    // If all specification were satisfied, you can assign the whole properties
    if(valid) 
    {
        VendorName = tbVendorName.Text;          
        VendorAddress = rtbVendorAddress.Text;
        VendorEmail = tbVendorEmail.Text;
        VendorWebsite = tbVendorWebsite.Text;
    }
    else
    {
         // If not, generates a message box with a comma-separated 
         // list of required fields!
         MessageBox.Show
         (
                string.Format
                (
                      "The following fields are required: {0}",
                      textBoxSpec.RequiredFields.ToArray().Join(", ")
                )
         );  
    }
