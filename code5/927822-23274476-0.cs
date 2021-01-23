    sqlDa.Fill(dt);
    
    if (dt.Rows.Count = 0)
    {
       DataRow rw = dt.NewRow();
       rw["status"] = "";
       rw["Total"] = 0;
       dt.Rows.Add(rw);
    
    }
    
    Chart1.DataSource = dt;
    Chart1.DataBind();
    
    con.Close();
