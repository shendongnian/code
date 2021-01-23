    private void btnLoad_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString) )
        {
          conn.Open();
          using(SqlCommand cmd2 = new SqlCommand("Select * from " + cmbItemLookup.Text, conn) )
          {
            using(SqlDataReader rdr2= cmd2.ExecuteReader())
            {
              try
              {
                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = cmd2;
                DataTable dt = new DataTable();
                ada.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgvExport.DataSource = bs;
                ada.Update(dt);
                conn.Close();
              }
              catch (Exception Ex)
              {
                MessageBox.Show(Ex.Message);
              }
            }
          }
        }
    }
