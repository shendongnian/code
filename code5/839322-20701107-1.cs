    var test = Session["CustType"] as string;
    if (!string.IsNullOrEmpty(test))
    {
        txtCustomerType.Text = test;
    }
