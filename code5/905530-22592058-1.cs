    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string conn = "";
                string sqlCOmmand = "inset blablabla into blablabla";
                conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
                InsertRow(conn, sqlCOmmand);
            }
        }
