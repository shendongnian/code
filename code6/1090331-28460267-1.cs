          protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["timeCount"] == null)//this avoid resetting of the session on postback
                {
                    Session["timeCount"] = 1;
                }
            
            }
            protected void Timer1_Tick(object sender, EventArgs e)
            {
                Int32 count = Convert.ToInt32(Session["timeCount"].ToString());
                if (count > 0)
                {
                    Label1.Text = (count + 1).ToString();
                    count=count+1;
                }
                Session["timeCount"]=count;
            }
