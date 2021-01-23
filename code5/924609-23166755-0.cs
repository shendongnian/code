    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                DataSet ptDataset = new DataSet();
                string con = ConfigurationManager.ConnectionStrings["secaloFormulaCS"].ToString();
                SqlConnection sqlCon = new SqlConnection(con);
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spDispProductInfo", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox2.SelectedValue.ToString()));
                sqlCmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ptDataset);
                dataGridView2.DataSource = ptDataset;
                sqlCon.Close();
    
            }
