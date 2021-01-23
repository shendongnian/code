    public void UpdateCustomer(User customer)
    {
        string updateSql =
        @"UPDATE Client
        SET cFirstName = @FirstName,
            cLastName  = @LastName,
            cDOB       = @DateOfBirth,
            cAddress   = @Address,
            cZipCode   = @ZipCode,
            cPhoneNo   = @PhoneNumber,
            cFax       = @FaxNumber,
            cEmail     = @Email,
            cPassword  = @Password
        WHERE ClientNo = @Id";
        using (var connection = new SqlConnection(@"..."))
        {
            connection.Open();
            var command = new SqlCommand(updateSql, connection);
            var args = command.Parameters;
            args.Add("@FirstName", customer.FirstName);
            args.Add("@LastName", customer.LastName);
            args.Add("@DateOfBirth", customer.DateOfBirth);
            args.Add("@Address", customer.Address);
            args.Add("@ZipCode", customer.ZipCode);
            args.Add("@PhoneNumber", customer.PhoneNumber);
            args.Add("@FaxNumber", customer.FaxNumber);
            args.Add("@Email", customer.Email);
            args.Add("@Password", customer.Password);
            args.Add("@Id", customer.Id);
            command.ExecuteNonQuery();
        }
        UFlag = "T";
    }
