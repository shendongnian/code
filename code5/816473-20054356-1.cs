    protected void Page_Load(object sender, EventArgse)
        {
            if (!IsPostBack)
            {
                DataTable oDataTable = newDataTable();
                oDataTable = SelectDataTable(“SELECT  MenuID, ParentID, Name, URL FROM     Menus”);
                DataRow[] drParentMenu = oDataTable.Select(“ParentID = 0″);
                var oStringBuilder = newStringBuilder();
                string MenuList = GenerateMenu(drParentMenu, oDataTable, oStringBuilder);
                Literal1.Text = MenuList;
            }
        }
