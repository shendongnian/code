      DataTable dt = new DataTable();
      dt.Columns.Add("Subject");
      dt.Columns.Add("Message");
    
      DataRow dr = dt.NewRow();
      dr["Subject"] = "Subject1";
      dr["Message"] = "Message1";
      list.DataSource = dt;
      list.DataBind();
