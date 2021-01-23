    string strcon = "Data Source=client-2;Initial Catalog=Name;Integrated Security=True;Pooling=False";
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            DataGridViewComboBoxColumn dgvCmb;
            public Form2()
            {
                InitializeComponent();
                grdcmd();
            }
            public void grdcmd()
            {
                con = new SqlConnection(strcon);
                con.Open();
                string qry = "Select * from Dbname";
                da = new SqlDataAdapter(qry, strcon);
                dt = new DataTable();
                da.Fill(dt);
                dgvCmb = new DataGridViewComboBoxColumn();
                foreach (DataRow row in dt.Rows)
                {
                    dgvCmb.Items.Add(row\["Fname"\].ToString());
                }
                dataGridView1.Columns.Add(dgvCmb);
            }
    see output
