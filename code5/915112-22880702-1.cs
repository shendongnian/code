     protected void Page_Load(object sender, EventArgs e)
        {
    	string v = Request.QueryString["DarkhastId"];
    	if (v != null)
    	{
    	    Response.Write("param is ");
    	    Response.Write(v);
    	}
        }
    }
