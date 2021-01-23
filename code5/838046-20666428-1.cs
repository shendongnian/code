    protected void Page_Load(object sender, EventArgs e)
    {
        var lb = new LinkButton { Text = "log out" };
        lb.Click += (o, i) => { Session["user"] = null; };
        mydiv.Controls.Add(lb);
    }
