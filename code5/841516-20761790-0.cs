    private ArrayList cart
    {
        get
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new ArrayList();
            }
            return (ArrayList)Session["Cart"];
        }
        set
        {
            Session["Cart"] = value;
        }
    }
    protected void addtocart_Click(object sender, EventArgs e)
    {
        int dealid = Convert.ToInt32(Request.QueryString.Get("deal"));
        cart.Add(dealid);
        foreach (var item in cart)
        {
            Response.Write(item.ToString());
        }
    }
