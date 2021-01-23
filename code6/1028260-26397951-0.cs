    string InsMus = @"Insert into StoreMus (MusNo,MusDate)
                       Values (@MusNo, @MusDate);";
    using(var con = new SqlConnection("Connection String..."))
    using(var cmd = new SqlCommand(InsMus, con))
    {
        cmd.Parameters.Add("@MusNo", SqlDbType.SmallInt).Value = short.Parse(txtMusNo.Text);
        cmd.Parameters.Add("@MusDate", SqlDbType.Date).Value = DateTime.Parse(txtMusDate.Text);
        con.Open();
        int inserted = cmd.ExecuteNonQuery();
    }
