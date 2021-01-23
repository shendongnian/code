            string Query = "SELECT ColumnName FROM TableName";
            using(SqlCommand comSQL = connectionDB.CreateCommand())
            {
                comSQL.CommandText = Query;
                    using (SqlDataReader drSql = comSQL.ExecuteReader())
                    {
                        while (drSQL.Read())
			            {
			                ComboBox.Items.Add(drSQL.GetString(0));
			            }
                    }
            }
