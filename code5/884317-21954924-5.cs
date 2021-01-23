    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataTable dtSource = (DataTable)dataGridView2.DataSource;
        MessageBox.Show(dtSource.TableName,"");  // check the value of TableName
        
        if (dtSource.TableName == "sewagram express")
        {
            SqlCommand cm1 = new SqlCommand("select * from sewagram", con);
            DataTable dth = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm1);
            da.Fill(dth);
            dataGridView1.DataSource = dth;
        }
    }
