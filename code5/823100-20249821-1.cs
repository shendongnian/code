    private void button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(textBox1.Text) > 36)            
            MessageBox.Show("Insert a valid data");
        else
        {
            using(OleDbConnection cn = new OleDbConnection())
            using(OleDbCommand comm = new OleDbCommand("insert into ins_number (numb) values (?)", cn))
            {
                 cn.Open();
                 comm.Parameters.AddWithValue("@p1",Convert.ToInt32(this.textBox1.Text));
                 comm.ExecuteNonQuery();
                 da = new OleDbDataAdapter("select Number,[Red],[Black],[1_18],[19_36],[Even],[Odd],"+ 
                                  "[1Column],[2Column],[3Column],[1Dozen],[2Dozen],[3Dozen] " +
                                  "from [ins_number] where numb=? order by [Id_Numb] desc");
                 da.SelectCommand.Parameters.AddWithValue("@p1", Convert.ToInt32(this.textBox1.Text));
                 ds = new DataSet();
                 da.Fill(ds);
                 dataGridView1.DataSource = ds.Tables[0];        
            }
        }
    }
