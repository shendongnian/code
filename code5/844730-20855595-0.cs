    private void button4_Click(object sender, EventArgs e)
    {
    if(ListU.SelectedValue == null || ListU.SelectedValue.ToString() == string.Empty)
       {
           MessageBox.Show("Select something from the listbox, please");
           return;
       }
    esle
       {
       //update code//
       SqlConnection conn = new SqlConnection();
       conn.ConnectionString = "Data Source=PEWPEWDIEPIE\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
       conn.Open();
    
       SqlDataAdapter daCount = new SqlDataAdapter("select iCount from ComDet where cName = @cName", conn);
       daCount.SelectCommand.Parameters.Add("@cName", SqlDbType.VarChar).Value = ListU.SelectedValue;
    
       DataTable dtC = new DataTable();
       daCount.Fill(dtC);
       DataRow firstRow = dtC.Rows[0];
    
       string x = firstRow["iCount"].ToString();
       int y = Int32.Parse(x);
       int z = y + 1;
    
       SqlCommand cmdC = conn.CreateCommand();
       cmdC.CommandText = "Update ComDet set iCount = " + z + ", ViewTime = '" + lblTime.Text + "', LastView = '" + txtUser2.Text + "' Where cName = '" + ListU.SelectedValue.ToString() + "'";
    
        cmdC.ExecuteNonQuery();
        conn.Close();
    
        var ufdet = new UserFullDetail(ListU.SelectedValue.ToString());
        ufdet.ShowDialog();
        }
    }
