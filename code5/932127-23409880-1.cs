    Page_Load(...)
    {
        if(!IsPostback)
        {
          string id = Request.QueryString["id"] as string;
          if(id!=null)
          {
             //query the database and populate the data
          }
        }
    }
