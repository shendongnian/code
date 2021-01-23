    protected void Button1_Click(object sender, EventArgs e)
    {
        User customer = new User()
        {
            Id = long.Parse((string)Session["sUserId"]),
            FirstName = firstnameTB.Text.Trim(),
            LastName = lastnameTB.Text.Trim(),
            DateOfBirth = DateTime.Parse(dobTB.Text.Trim()),
            Address = addressTB.Text.Trim(),
            ZipCode = zipcodeTB.Text.Trim(),
            PhoneNumber = phonenumberTB.Text.Trim(),
            FaxNumber = faxnumberTB.Text.Trim(),
            Email = emailTB.Text.Trim(),
            Password = passwordTB.Text.Trim()
        };
        UpdateCustomer(customer);
        if (UFlag == "T")
        {
            Type strType = this.GetType();
            ClientScript.RegisterStartupScript(strType, "Success", scriptSuccessUpdate);
        }
    }
