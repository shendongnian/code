     private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Table1",con);
            da.Fill(dt);
           
            listBox1.DataSource = dt;
            // listBox1.ValueMember = "data";  //data is one of the coloumn of the table...
           
        }
