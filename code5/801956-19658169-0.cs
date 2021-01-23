    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Cookies["BackgroundColor"] != null)
        {
            ColorSelector.SelectedValue = Request.Cookies["BackgroundColor"].Value;
            BodyTag.Style["background-color"] = ColorSelector.SelectedValue;
        }
    }
    protected void ColorSelector_IndexChanged(object sender, EventArgs e)
    {
        BodyTag.Style["background-color"] = ColorSelector.SelectedValue;
        HttpCookie cookie = new HttpCookie("BackgroundColor");
        cookie.Value = ColorSelector.SelectedValue;
        cookie.Expires = DateTime.Now.AddHours(1);
        Response.SetCookie(cookie);
    }
