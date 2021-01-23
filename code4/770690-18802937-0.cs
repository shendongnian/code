                string query= "Select * from tblUsers Where (user_id=@id AND user_password=@pwd)";
                
                CN.Open();
                SqlCommand myCommand = new SqlCommand(txt, CN);
                myCommand.Parameters.Add(new SqlParameter("id", SqlDbType.NVarChar)).Value = this.txtUserID.Text;
                myCommand.Parameters.Add(new SqlParameter("pwd", SqlDbType.NVarChar)).Value = this.txtPassword.Text;
                SqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                myReader.Read();
                if (myReader.HasRows)
                {
                   
                    CN.Close();
                    AdminForm mf = new AdminForm();
                    mf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid User Name or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
