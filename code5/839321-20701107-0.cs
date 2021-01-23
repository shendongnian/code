    var test = Session["CustType"]  as string;
    if (string.IsNotNull(test))
    {
        txtCustomerType.Text = test;
    }
