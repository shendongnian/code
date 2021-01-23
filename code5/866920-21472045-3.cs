    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie c = Request.Cookies["FirstName"];
        if (c == null)
        {
            c = new HttpCookie("FirstName");
        }
    
        c.Value = TextBox1.Text;
        c.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(c);
    }
