    internal static void FillComboBox(ComboBox ComboBox, string valueMember, string displayMember, string tableName)
        {
            SqlConnection ConnName = new SqlConnection();
            ConnName.ConnectionString = "YourSqlConnString";
            ConnName.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("Select " + valueMember + " ," + displayMember + "  from " + tableName, ConnName);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            ComboBox.ValueMember = Value;
            ComboBox.DisplayMember = DisplayName;
            ComboBox.DataSource = dt;
            ConnName.Close();
        }
