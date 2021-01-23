    protected void Page_Load(object sender, EventArgs e)
                {
                    int x = 0;
                    double y = 0;
                    x = Int32.Parse(Request["x"].ToString());
                    y = Double.Parse(Request["y"].ToString());
                    //Run some more code
                    Response.Redirect("Default.aspx?Param1=xxxx&Param2=xxxx");
                    //passed the params in the redirect.
                 }
