    String q6 = "insert into sold select @LotNo, @c, @rcno, date from lot LIMIT @m , @n;";
    MySqlCommand c6 = new MySqlCommand(q6, cn);
    //I'm guessing a column types. Use actual DB column types and lengths here
    c6.Parameters.Add("@LotNo", MySqlDbType.VarChar, 6).Value = lotno;
    c6.Parameters.Add("@c", MySqlDbType.VarChar, 20).Value = c;
    c6.Parameters.Add("@rcno", MySqlDbType.VarChar, 6).Value = rcno;
    c6.Parameters.Add("@m", MySqlDbType.Int).Value = m;
    c6.Parameters.Add("@n", MySqlDbType.Int).Value = n;
    
    c6.ExecuteNonQuery();
