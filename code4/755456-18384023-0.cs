    double val;
    if (!Double.TryParse(values8[x], out val))
       com.Parameters.Add("@p1", OleDbType.Date, 255).Value = DBNull.Value;
    else
       com.Parameters.Add("@p1", OleDbType.Date, 255).Value = DateTime.FromOADate(val + 24837);
