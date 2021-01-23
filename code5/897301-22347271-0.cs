    DataTable schema = null;
    using (var con = new SqlConnection(connection))
    {
        using (var schemaCommand = new SqlCommand("SELECT * FROM Add_Information", con))
        {
            con.Open();
            using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                schema = reader.GetSchemaTable();
            }
        }
    }
    datagridFieldCreation.DataSource = schema;
