    using(var conn = new SqlConnection("YOUR CONNECTION STRING ..."))
    using (var cmd = new SqlCommand("INSERT INTO VOTER (THUMB) VALUES(@THUMB)", conn)) {
        conn.Open();
        var param = new SqlParameter("@THUMB", SqlDbType.Binary) {
            // here goes your binary data (make sure it's correct)
            Value = thumb.GetTemplateBuffer().ToArray()
        };
        cmd.Parameters.Add(param);
        int rowsAffected = cmd.ExecuteNonQuery();
        // do your other magic ...
    }
