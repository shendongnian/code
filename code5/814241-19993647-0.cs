    protected void register_Click(object sender, EventArgs e)
    {
            //var path = Path.Combine(Request.PhysicalApplicationPath, "App_Data\\PageData.xml");
        File.Exists("~/App_Data/userlogs.xml");
        {
            XDocument doc = XDocument.Load(Server.MapPath("~/App_Data/userlogs.xml"));
            XElement user = new XElement("user",
                new XElement("fname", fname.Text.ToString()),
                new XElement("lname", lname.Text.ToString()),
                new XElement("dob", dob.Text.ToString()),
                new XElement("uid", uid.Text.ToString()),
                new XElement("pwd", pwd.Text.ToString()),
                new XElement("email", email.Text.ToString()),
                new XElement("lastlog", System.DateTime.Now.ToString())
                );
            doc.Root.Add(user);
            doc.Save(Server.MapPath("~/App_Data/userlogs.xml"));
        }
    }
