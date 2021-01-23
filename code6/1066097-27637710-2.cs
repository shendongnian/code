    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["username"] != null && Request.QueryString["email"] != null && Request.QueryString["msg"] != null)
        {
            try
            {
                string name = Request.QueryString[0];
                string email = Request.QueryString[1];
                string msg = Request.QueryString[2];
                SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
                //smtp.EnableSsl = false;
                smtp.Send("feedback@solutionpoint98.com", "b.soham1991@gmail.com", "feedback", "Name:" + name + "\n e-mail:" + email + "\n Subject:" + msg);
                Response.Redirect("contact.html?msg=success", false);
            }
            catch(Exception ex)
            {
                Response.Redirect("contact.html?msg=fail", false);
            }
        }
        else
        {
            Response.Redirect("contact.html", false);
        }
    }
