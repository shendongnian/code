    protected void btnPayment_Click(object sender, EventArgs e)
    {
        ClsDictionary dict = new ClsDictionary();
        dict.AddDetail("Email", txtEmail.Text);
        dict.AddDetail("FirstName", txtFname.Text);
        dict.AddDetail("LastName", txtLname.Text);
        dict.AddDetail("Address1", txtAddress1.Text);
        dict.AddDetail("Address2", txtAddress2.Text);
        dict.AddDetail("City", txtCity.Text);
        dict.AddDetail("State", txtState.Text);
        dict.AddDetail("Country", txtCountry.Text);
        dict.AddDetail("PinCode", txtPincode.Text);
        dict.AddDetail("Phone", txtPhone.Text);
        dict.AddDetail("Country", txtCountry.Text);
    }
