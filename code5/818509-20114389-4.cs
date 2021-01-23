    if ((Request.QueryString["SChn"] != null) && (!(Request.QueryString["SChn"].Trim().Equals(""))))
    {
       if ((Request.QueryString["PAN"] != null) && (!(Request.QueryString["PAN"].Trim().Equals(""))))
       {
          if ((Request.QueryString["STag"] != null) && (!(Request.QueryString["STag"].Trim().Equals(""))))
          {
             if ((Request.QueryString["MAC"] != null) && (!(Request.QueryString["MAC"].Trim().Equals(""))))
             {
                insertData();
             }
          }
       }
    }
