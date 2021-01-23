    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string table = listBox2.SelectedItem.ToString();
        using (SqlConnection con = new SqlConnection(strConnect))
        {
            con.Open();
            using (SqlCommand com = new SqlCommand(@"SELECT * FROM " + table, con))
            {
                using (SqlDataReader reader = com.ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    listBoxColumns.Items.Clear();
                    DataTable schemaTable = reader.GetSchemaTable();
                    foreach(DataRow colRow in schemaTable.Rows)
                        listBoxColumns.Items.Add(colRow.Field<String>("ColumnName"));
                }
            }
        }
    }
