    if   (!Page.IsPostBack)
        {
            Panel_View.Visible = false;
            Session["SearchtText"] = null;
            Session["ColumnName"] = null;
            this.FillGrid((String)Session["ColumnName"] ?? null, (String)Session["SearchtText"] ?? null);
            Bind_DDL_Column_List();
            Bind_DDL_Title();
            Bind_DDL_Countries();
        }
            Bind_DDL_Status();
            Bind_DDL_Group();
        this.GetData();
