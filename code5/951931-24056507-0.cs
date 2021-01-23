    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string userName = HttpContext.Current.User.Identity.Name;
        if (OrderService.GetOrder(id).User.Username == username)
        {
          Response.Write("id is " + id);
        }
        else
        {
          throw new SecurityException("User does not have permission to access another user's order.");
        }
    }
