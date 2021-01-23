            string con_string = @"data Source= 10.10.10.5;initial catalog= test; user= xx; password= xxxxxxxxx;";
            SqlConnection con = new SqlConnection(con_string);
            string qryUpdate = @"Update ExpenseManagement 
                                 set FirstName= @FirstName, 
                                    LastName=@LastName, 
                                    Password=@Password,
                                    EmailId=@EmailId,
                                    MobileNumber=@MobileNumber 
                                    where UserId= @UserId";
            SqlCommand cmd = new SqlCommand(qryUpdate, con);
            cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@EmailId", txtEmailId.Text);
            cmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text);
            con.Open();
            if (Page.IsValid)
            {
                cmd.ExecuteNonQuery();
                btnEdit.Visible = true;
            }
            con.Close();
        }
