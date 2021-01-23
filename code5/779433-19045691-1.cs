    protected void Page_Load(object sender, EventArgs e)
    {
        div1.Visible = div2.Visible = div3.Visible = false;
        if (Session["Counter"] != null)
        {
            int GetSession = (int)Session["Counter"];
            if (GetSession == 1)
                div1.Visible = true;
            else if (GetSession == 2)
                div2.Visible = true;
            else
                div3.Visible = true;
        }
        else
            div3.Visible = true;
    }
