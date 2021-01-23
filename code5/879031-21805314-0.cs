        public void SelectEmployee()
        {
            Query = "SELECT Employee_Name FROM TblEmployees";
            reader = conn.ExecuteStatement(Query);
            while (reader.Read())
            {
                ComboBox1.Items.Add(reader["Employee_Name"].ToString());
            }
            conn.CloseConnection();
        }
