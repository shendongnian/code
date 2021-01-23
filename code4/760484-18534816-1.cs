    using (SqlConnection sql = new SqlConnection("...")) {
        query.Append(string.Format("INSERT INTO {0} ({1}) VALUES ({2})", this._TABLE_, col, val));
        using (SqlCommand sqlCmd = new SqlCommand(query.ToString(), sql) {
            sql.Open();
            sqlCmd.ExecuteNonQuery();
        }
    }
