      public string username 
      { 
         get { return Session["username"] as string; }
         set { Session["username"] = value; }
      }
