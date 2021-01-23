    protected void Page_Load(object sender, EventArgs e)
        {
            DBconnect dbcon = new DBconnect();
            string confirm = Request.Params["Confirm"];
            if (dbcon.CheckActivation(confirm) == true)
            {
                dbcon.UpdateStatus(confirm);
            }
        }
