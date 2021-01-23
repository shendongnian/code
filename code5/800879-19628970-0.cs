    protected void Page_Load(object sender, EventArgs e)
    {
        String email= Request.QueryString["email"];
        String mobNumber= Request.QueryString["mob"];
	    String yourThirdParameter = Request.QueryString["thirdOne"]; // Provide your third parameter.
        SqlDataAdapter da = new SqlDataAdapter("insert into login values('" + email + "','" + mob + "','" + yourThirdParameter  + "')",con);
	// Assuming this is the sequence.you can change it your way.
        DataSet ds = new DataSet();
        da.Fill(ds);
     
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Redirect")
        {
            String email = lblemail.Text;
            String mob = lblmobno.Text;
	        String thirdOne= // Fill it as is the need
            Server.Transfer("activate.aspx?email=" + email+"&mob=" +mob+"&thirdOne="+thirdOne, true);
        }
    }
