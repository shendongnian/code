    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegDNMembershipConnectionString"].ConnectionString))
    {
        con.Open();
        string insCmd = "Insert into Accounts (AccountName, Passphrase, EmailAddress, FullName, Country) VALUES (@AccountName,@Passphrase,@EmailAddress,@FullName,@Country)";
        using (var insertUser = new SqlCommand(insCmd, con))
        {
            ...
        }
    }
