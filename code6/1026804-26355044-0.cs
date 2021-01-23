    BTNUpdateCustomer.Enabled = false;
    BTNDeleteCustomer.Enabled = false;
    foreach (DataRow row in table.Rows)
    {
       string companyName = row.Field<string>("CompanyName");
       if(companyName == TXTBXCustomerLookup.Text)
       {
           BTNUpdateCustomer.Enabled = true;
           BTNDeleteCustomer.Enabled = true;
           break;
       }
    }
