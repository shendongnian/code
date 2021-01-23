    public void Save(Literal L) 
    { 
      Response.ContentType = "application/ms-excel";
      Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
      Response.Write("<head>");
      ------------------
      --------------------
     Response.End();//call this
    }
