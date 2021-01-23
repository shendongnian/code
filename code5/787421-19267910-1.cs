    protected void Page_Load(object sender, EventArgs e) {
        if (this.Page.PreviousPage != null) {
            //Retrieve values from Session Variables
            Response.Write("PatientId: " + Session["PatientId"].ToString() + "<br />");
            Response.Write("firstname: " + Session["firstname"].ToString() + "<br />");
            Response.Write("lastname: " + Session["lastname"].ToString() + "<br />");
        }
    }
