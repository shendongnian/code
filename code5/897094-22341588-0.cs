	SqlCommand cmd = new SqlCommand(@"INSERT INTO CustomerDetails
		(CustomerId, Date, Name, Gender, Address, Phone, Email, MobileNo,Notes)
		 VALUES  (@CustomerId, @Date, @Email, @Mobile, @Notes)", con);
	cmd.Parameters.Add("@CustomerId", SqlDbType.VarChar, 10).Value = txtCustomerID.Text;
	cmd.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = DateTime.Now;
	cmd.Parameters.Add("@Email", SqlDbType.VarChar, 10).Value = txtEmail.Text;
	cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, 10).Value = txtMobileNo.Text;
	cmd.Parameters.Add("@Notes", SqlDbType.VarChar, 10).Value = txtNotes.Text;
