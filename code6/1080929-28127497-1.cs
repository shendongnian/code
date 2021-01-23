    SqlDataReader reader = myCommand.ExecuteReader();
    while (reader.Read())
    {
       // grab next record selected
       int project_id = (int) reader[0];
       // do whatever you want with it
       if (Request.QueryString["ProjectId"] == project_id.ToString())
       {
       }
       else
       {
           Response.Redirect("projectlist.aspx");
       }
    }
