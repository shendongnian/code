    private void btnSearch_Click(object sender, EventArgs e)
    {
        string batch = Batch.Text;
        
        SqlCommand cmd = new SqlCommand(@"
                               SELECT
                                   *
                               FROM
                                   Student
                               WHERE
                                   Batch=@Batch");
    
       
        DataSet dst = SqlManager.GetDataSet(cmd);
        
        dataGridView1.DataSource = dst.Tables[0];
    
        Batch.Clear();
        Batch.Focus();
    }
