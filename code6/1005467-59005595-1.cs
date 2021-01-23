    public void insertfunction()
            { 
                
               string sqlconn = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
                SqlConnection cn = new SqlConnection(sqlconn);
                cn.Open();
                String query = "insert into PatientRecords values(@Patient_Name,@Cnic,@Phone,@Address,@Age,@Doctor_Reference,@City)";
                SqlCommand cmd = new SqlCommand(query,cn);
               // cmd.Parameters.AddWithValue("@Patient_Id", pid.Text);
                cmd.Parameters.AddWithValue("@Patient_Name", pname.Text);
                cmd.Parameters.AddWithValue("@Cnic", pcnic.Text);
                cmd.Parameters.AddWithValue("@Phone", pphone.Text);
                cmd.Parameters.AddWithValue("@Address", paddress.Text);
                cmd.Parameters.AddWithValue("@City", cmbopcity.GetItemText(cmbopcity.SelectedItem));
                cmd.Parameters.AddWithValue("@Age", page.Text);
                cmd.Parameters.AddWithValue("@Doctor_Reference", prefdoc.Text);
    
    
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Successfully inserted");
                }
                else
                {
                    MessageBox.Show("Record failed");
                }
                cn.Close();
                 
    
            }
