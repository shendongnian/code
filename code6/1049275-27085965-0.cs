     public void loadChart() {
        // this populates my chart with data from the database
        SqlConnection cnn = new SqlConnection(connectionString);
        SqlCommand sqlcmd = new SqlCommand("SELECT * FROM tbl_salary;", cnn);
        SqlDataReader dr;
        try
        {
            cnn.Open();
            dr = sqlcmd.ExecuteReader();
    this.chart1.Series["salaryChart"].Points.Clear();
            while (dr.Read())
            {
                this.chart1.Series["salaryChart"].Points.AddXY(dr.GetString(1), dr.GetInt32(2));
            }
            cnn.Close();
        }
        catch (Exception)
        {
        }
    }
