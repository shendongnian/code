    //I'm less worried about this query, as m and are likely integers. 
    // I still don't approve of the string concatenation, but I'll leave it alone for now
    String q6 = "select date from lot LIMIT " + m + "," + n + "";
    MySqlCommand c6 = new MySqlCommand(q6, cn);
    DateTime d = (DateTime)c6.ExecuteScalar(); //This should work just fine. 
    //but parameters are VERY IMPORTANT for this query
    String q7 = "insert into sold values( @LotNo, @c, @rcno, @date );";
    MySqlCommand c7 = new MySqlCommand(q7, cn);
    //I'm guessing a column types. Use actual DB column types and lengths here
    c7.Parameters.Add("@LotNo", MySqlDbType.VarChar, 6).Value = lotno;
    c7.Parameters.Add("@c", MySqlDbType.VarChar, 20).Value = c;
    c7.Parameters.Add("@rcno", MySqlDbType.VarChar, 6).Value = rcno;
    c7.Parameters.Add("@date", MySQlDbType.Date).Value = d;
    
    c7.ExecuteNonQuery();
