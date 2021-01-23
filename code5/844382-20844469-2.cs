    private void button4_Click(object sender, EventArgs e)
            {
                //need update code//
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=PEWPEWDIEPIE\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
                conn.Open();
    
                SqlDataAdapter daCount = new SqlDataAdapter("select iCount from ComDet where cName = @cName", conn);
                daCount.SelectCommand.Parameters.Add("@cName", SqlDbType.VarChar).Value = ListU.SelectedValue;
    
                DataTable dtC = new DataTable();
                daCount.Fill(dtC);
                DataRow firstRow = dtC.Rows[0];
    
                string x = firstRow["iCount"].ToString();
                
                int y = 0;
                if(Int32.TryParse(x,out y))
                {      
                    System.Diagnostics.Debug.WriteLine("iCount was an valid int32");      
                    int z = y + 1;
                
                    //SqlCeCommand cmdC = conn.CreateCommand();
                    SqlCommand cmdC = conn.CreateCommand();
                    cmdC.CommandText = "Update ComDet set iCount = " + z + ", ViewTime = '" + lblTime.Text + "', LastView = '" + txtUser2.Text + "' Where cName = '" + ListU.SelectedValue.ToString() + "'";
                 }
                else
                    System.Diagnostics.Debug.WriteLine("iCount was NOT a valid int32, value: " + x);
                 conn.Close();
    }
