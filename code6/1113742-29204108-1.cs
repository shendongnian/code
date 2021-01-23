     protected void Page_Load(object sender, EventArgs e)
    {
        //After  successfull log in
        if(Session["prevUrl"]!=null){
        Response.Redirect((string)Session["prevUrl"]); //Will redirect to previous page
        }else{
        Response.Redirect("To your home page");
        }
    }
