    string Id = DropDwonList.SelectedValue;
    
            using (SqlConnection sql = new SqlConnection("Your connection string"))
            {
                SqlCommand cmd = new SqlCommand();
                string query = @"INSERT INTO TABLE2(Column1)
                                   VALUES(" + Id + ")";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sql;
                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
            }
