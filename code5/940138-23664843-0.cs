    public void Page_Load(object sender, EventArgs e)
    {
        //you should probably also check to make sure the session has "permissionUser" in it
        if (Session["permissionUser"] == "1")
        {
            Permission1HL.Visible=true;
        }
        else if(Session["permissionUser"] == "2")
        {
            Permission2HL.Visible=true;
        }
    }
