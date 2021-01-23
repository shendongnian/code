    internal static void FillComboBox(ComboBox comboBoxName, string valueMember, string displayMember, string tableName)
        {
            SqlConnection connName = new SqlConnection();
            connName.ConnectionString = "YourSqlConnString";
            connName.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select " + valueMember + " ," + displayMember + "  from " + tableName, connName);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            comboBoxName.ValueMember = valueMember;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.DataSource = dt;
            connName.Close();
        }
