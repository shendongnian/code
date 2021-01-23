    private void button1_Click(object sender, EventArgs e)
    {
        string cmdText = "SELECT * From dbo.Tclients WHERE " + comboBox1.Text + " = @input";
        using(SqlConnection conn = new SqlConnection(....))
        using(SqlCommand cmd = new SqlCommand(cmdText, conn))
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@input", textBox1.Text);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
