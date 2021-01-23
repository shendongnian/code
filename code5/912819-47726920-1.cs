    protected void Page_Load(object sender, EventArgs e) {
    string xmlFile = Server.MapPath("~/Data.xml");
    XDocument document = XDocument.Load(xmlFile);
    var booksQuery = from b in document.Elements("NewDataSet").Elements("Table")
                      select b;
    DataTable table = booksQuery.ToDataTable();
    GridView1.DataSource = table;
    GridView1.DataBind();
