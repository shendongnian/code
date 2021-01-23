    protected void Page_Load(object sender, EventArgs e)
    {
        RoomClick();
    }
    private void RoomClick()
    {
        int roomId = 0;
        //check to see if the id in the querystring exists and that it parses as an int.
        if (!String.IsNullOrEmpty(Request.QueryString["id"]) && Int32.TryParse((Request.QueryString["id"]), out roomId))
        {
            //do whatever
        }
    }
