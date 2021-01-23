        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = createXMLPub();
                Label1.Text = Server.HtmlEncode(a);
            }
        }
        public static string createXMLPub()
        {
            XElement xeRoot = new XElement("pub");
            XElement xeName = new XElement("name", "###");
            xeRoot.Add(xeName);
            XElement xeCategory = new XElement("category", "#####");
            xeRoot.Add(xeCategory);
            XDocument xDoc = new XDocument(xeRoot);
           
            return xDoc.ToString();
        }
