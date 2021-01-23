    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string memberID = txtMember.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtTelephone.Text.Trim();
            string email = txtEmail.Text.Trim();
    
            sql = "INSERT INTO A_Member ( MemberID, LastName, FirstName, Phone, Email) VALUES ( @Member, @LastName, @FirstName, @Phone, @Email);";
            dbCmd = new OleDbCommand(sql, dbConn);
            dbCmd.Parameters.Add("@MemberID",SqlDbType.Int32).Value = Convert.ToInt32(memberID);
            dbCmd.Parameters.Add("@LastName",SqlDbType.Varchar,30).Value = lastName;
            dbCmd.Parameters.Add("@FirstName",SqlDbType.Varchar,30).Value = firstName;
            dbCmd.Parameters.Add("@Phone",SqlDbType.Int32).Value = Convert.ToInt32(phone);
            dbCmd.Parameters.Add("@LastName",SqlDbType.Varchar,30).Value = email;
    
            // Execute query
            dbCmd.ExecuteNonQuery();
        }
        catch (System.Exception exc)
        {
            MessageBox.Show(exc.Message);
            return;
        }
    }
