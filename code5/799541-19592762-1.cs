        private void LoadEmployeeAddress()
        {
            string con = ConfigurationManager.AppSettings["NorthwindDatabase"];
            string sql = "select address, city, region, postalcode from employees;";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
