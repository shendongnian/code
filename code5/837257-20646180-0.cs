    if (Request.Cookies["searchCounter"] != null)
    {
        if (Request.Cookies["searchCounter"].Value != "")
        {
            // some code...
            Response.Cookies["searchCounter"].Value = "some data";
            Response.Cookies["searchCounter"].Expires = DateTime.Now.AddDays(1);
        }
    }
    else
    {
        Response.Cookies["searchCounter"].Value = "some data";
        Response.Cookies["searchCounter"].Expires = DateTime.Now.AddDays(1);
    }
