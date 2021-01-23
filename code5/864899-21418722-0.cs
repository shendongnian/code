    cmd.CommandText = "SELECT contact_id as VendorID, company_name FROM t_contacts where type = 'V'";
    
    while (oleDbD8aReader != null && oleDbD8aReader.Read())
    {
        if (!oleDbD8aReader.IsDBNull(0))
        {
            vendorId = oleDbD8aReader.GetString(0);
        }
        else
        {
            vendorId = "blank";
        }
        if (!oleDbD8aReader.IsDBNull(1))
        {
            companyName = oleDbD8aReader.GetString(1);
        }
        else
        {
            companyName = "blank";
        }
        Add(new Vendor { VendorId = vendorId, CompanyName = companyName });
    }
