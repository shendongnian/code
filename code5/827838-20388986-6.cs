    protected void Button1_Click(object sender, EventArgs e)
    {
    	
    	string auid = String.IsNullOrEmpty(Request.QueryString["id"]) ? "1" : Request.QueryString["id"];
    
    	XmlDocument doc = new XmlDocument();
    	doc.Load(Server.MapPath("~/App_Data/discussion.xml"));
    	XmlNode author = doc.SelectSingleNode(string.Format("//author[@id={0}]", auid));
    	XmlNode comment = doc.CreateNode(XmlNodeType.Element, "comment", "");
    	comment.InnerText = messageTxb.Text;
    	XmlNode name = doc.CreateNode(XmlNodeType.Element, "name", "");
    	name.InnerText = nameTxb.Text.Trim();
    	XmlNode date = doc.CreateNode(XmlNodeType.Element, "date", "");
    	date.InnerText = string.Format("{0:D}", DateTime.Now);
    	XmlNode message = doc.CreateNode(XmlNodeType.Element, "message", "");
    	message.InnerText = messageTxb.Text.Trim();
    	comment.AppendChild(name);
    	comment.AppendChild(date);
    	comment.AppendChild(message);
    	author.AppendChild(comment);
    	doc.Save(Server.MapPath("~/App_Data/discussion.xml"));
    	nameTxb.Text = "";
    	messageTxb.Text = "";
    	XmlDataSource1.DataFile = Server.MapPath("~/App_Data/discussion.xml");
    	XmlDataSource1.XPath = "root/author[@id='" + auid + "']/comment";
    	Repeater1.DataBind();
    }
