    private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("connString");
            SqlCommand cmd = new SqlCommand("SELECT * FROM myTable;",sql);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmbCity.DataSource = dt;
            cmbCity.DisplayMember = "cityname";
            cmbCity.ValueMember = "refrence_no";
            txtReferenceNo.Text = cmbCity.SelectedItem.ToString();
        }
        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtReferenceNo.Text = cmbCity.SelectedItem.ToString();
        }
