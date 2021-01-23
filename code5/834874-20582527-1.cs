    con.Open();
    type = checkBox49.Text;
    
    String str = "Select * from distro where type=?";
    cmd = new OleDbCommand(str, con);
    cmd.Parameters.Add(type);
    using (dr = cmd.ExecuteReader())
        if (dr.Read())
        {
            var values = new object[dr.FieldCount];
            dr.GetValues(values);
            str2 = string.Join(";", values.Select(d => d.ToString());
        }
    }
