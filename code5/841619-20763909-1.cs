    private void btnID_Click(object sender, EventArgs e)
    {
       try
       {
           string sql = "INSERT INTO Students([Student ID],[Student Name]) " + 
                        "values (@id, @name";
            using(SqlConnection myconnection = new SqlConnection(....))
            using(SqlCommand exeSql = new SqlCommand(sql, myconnection))
            {
               myconnection.Open();
               exeSql.Parameters.AddWithValue("@id",Convert.ToInt32(txtID.Text));
               exeSql.Parameters.AddWithValue("@name",txtName.Text);
               exeSql.ExecuteNonQuery(); 
            }
       }
       .....
