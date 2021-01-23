    protected void Page_Load(object sender, EventArgs e) {
        if (this.Page.PreviousPage != null) {
            //Retrieve values from Query Strings
            Response.Write("PatientId: " + Request.QueryString["parentid"].ToString() + "<br />");
            Response.Write("firstname: " + Request.QueryString["firstname"].ToString() + "<br />");
            Response.Write("lastname: " + Request.QueryString["lastname"].ToString() + "<br />");
        }
    }
