    protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
    
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddRecord";
            command.Connection.Open();
    
            SqlParameter pCustID = new SqlParameter();
            pCustID.ParameterName = "@CustID";
            pCustID.SqlDbType = SqlDbType.Int;
            pCustID.Direction = ParameterDirection.Input;
            pCustID.Value = txtCustID.Text;
            command.Parameters.Add(pCustID);
    
            SqlParameter pFirst = new SqlParameter();
            pFirst.ParameterName = "@First";
            pFirst.SqlDbType = SqlDbType.VarChar;
            pFirst.Direction = ParameterDirection.Input;
            pFirst.Value = txtFirstName.Text;
            command.Parameters.Add(pFirst);
    
            SqlParameter pSurn = new SqlParameter();
            pSurn.ParameterName = "@Surname";
            pSurn.SqlDbType = SqlDbType.VarChar;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = txtSurname.Text;
            command.Parameters.Add(pSurn);
    
            SqlParameter pGen = new SqlParameter();
            pSurn.ParameterName = "@Gender";
            pSurn.SqlDbType = SqlDbType.VarChar;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = rblGender.SelectedValue;
            command.Parameters.Add(pGen);
    
            SqlParameter pAge = new SqlParameter();
            pSurn.ParameterName = "@Age";
            pSurn.SqlDbType = SqlDbType.Int;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = txtAge.Text;
            command.Parameters.Add(pAge);
    
            SqlParameter pAdd1 = new SqlParameter();
            pSurn.ParameterName = "@Address1";
            pSurn.SqlDbType = SqlDbType.VarChar;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = txtAddress1.Text;
            command.Parameters.Add(pAdd1);
    
            SqlParameter pAdd2 = new SqlParameter();
            pSurn.ParameterName = "@Address2";
            pSurn.SqlDbType = SqlDbType.VarChar;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = txtAddress2.Text;
            command.Parameters.Add(pAdd2);
    
            SqlParameter pCity = new SqlParameter();
            pSurn.ParameterName = "@City";
            pSurn.SqlDbType = SqlDbType.VarChar;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = txtCity.Text;
            command.Parameters.Add(pCity);
    
            SqlParameter pPhone = new SqlParameter();
            pSurn.ParameterName = "@Phone";
            pSurn.SqlDbType = SqlDbType.VarChar;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = txtPhone.Text;
            command.Parameters.Add(pPhone);
    
            SqlParameter pMobile = new SqlParameter();
            pSurn.ParameterName = "@Mobile";
            pSurn.SqlDbType = SqlDbType.VarChar;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = txtMobile.Text;
            command.Parameters.Add(pMobile);
    
            SqlParameter pEmail = new SqlParameter();
            pSurn.ParameterName = "@Email";
            pSurn.SqlDbType = SqlDbType.VarChar;
            pSurn.Direction = ParameterDirection.Input;
            pSurn.Value = txtEmail1.Text;
            command.Parameters.Add(pEmail);
    
            SqlDataReader reader = command.ExecuteReader();
    
            reader.Dispose();
            command.Dispose();
            conn.Dispose();
        }
    }
