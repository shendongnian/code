           protected void Page_Load(object sender, EventArgs e)
            {    
    MultiView mv = (MultiView)Master.FindControl("multiView1");
                    var GetSession = Session["Counter"];
                    if (Convert.ToInt32(GetSession) == 1)
                    {
                        mv.ActiveViewIndex = 0
                    }
                    else if (Convert.ToInt32(GetSession) == 2)
                    {
                        mv.ActiveViewIndex = 1
                    }
                    else
                    {
                        mv.ActiveViewIndex = 2
                    }
                }
