	protected void addtocart_Click(object sender, EventArgs e)
	{
		int dealid = Convert.ToInt32(Request.QueryString.Get("deal"));
		ArrayList cart1 = new ArrayList();
		cart1 = (ArrayList)Session["Cart"];
		cart1.Add(dealid);
		Session["Cart"] = cart1;
        // iterate items in session
		ArrayList cart = Session["Cart"] as ArrayList;
		foreach(var item in cart)
		{
			Response.Write(item.ToString());
		}
	}
