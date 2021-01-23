    var insertCmd = "INSERT INTO tbl (fld1, fld2) VALUES (@fld1, @fld2); SELECT SCOPE_IDENTITY()";
    using (var c = new SqlConnection(connString))
    using (var cmd = new SqlCommand(insertCmd, c))
    {
        cmd.AddParameterWithValue("@fld1", fld1Value);
        cmd.AddParameterWithValue("@fld2", fld2Value);
        var result = cmd.ExecuteScalar();
        int id;
        if (int.TryParse(result, out id))
        {
            // update the DataTable row here
            dataTable.Rows[index]["id_column"] = id;
            dataTable.AcceptChanges();
        }
    }
