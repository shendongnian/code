    protected void Page_Load(object sender, EventArgs e)
    {
        mydiv.Controls.Add
        (
            new LinkButton { Text = "log out" } 
            .Click += (o, i) => { Session["user"] = null; }
        );
    }
