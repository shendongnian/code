    protected void btnPayment_Click(object sender, EventArgs e)
    {
        ClsDictionary dict = new ClsDictionary();
        Dictionary<string, string> Values = dict.getDictionary();
        Values.Add("Email", txtEmail.Text);
        Values.Add("FirstName", txtFname.Text);
        Values.Add("LastName", txtLname.Text);
        Values.Add("Address1", txtAddress1.Text);
        Values.Add("Address2", txtAddress2.Text);
        Values.Add("City", txtCity.Text);
        Values.Add("State", txtState.Text);
        Values.Add("Country", txtCountry.Text);
        Values.Add("PinCode", txtPincode.Text);
        Values.Add("Phone", txtPhone.Text);
        Values.Add("Country", txtCountry.Text);
    }
