       private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
          
            con.ConnectionString = "Data Source=.;Initial Catalog=StudentDetails;Integrated Security=True";
            cmd.Connection = con;
            cmd.CommandText = "select * from studet";
            da.SelectCommand = cmd;
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
     ////////////////////////////////////////////////////
            DataRow dr = dt.NewRow();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr[0] = dt.Rows[i][0];
                comboBox1.Items.Add(dr[0]);
            }
        }
