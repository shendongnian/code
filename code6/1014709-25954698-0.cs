    public Guid UserID
    {
       get
          {
               if(Session["_USERID"] != null)
                  return (Guid)Session["_USERID"];
          }
       set
          {
               Session["_USERID"] = value;
          }
    }
