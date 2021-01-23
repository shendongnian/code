    public DataTable AllRecords { get { return Session["AllRecords"]; } set { Session["AllRecords"] = value;} }
    public string TableName;
    BLTablesSearch _BLTablesSearch = new BLTablesSearch();
    public delegate void SearchComplete(DataTable FilteredData);
    public event SearchComplete OnSearchComplete;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DDLSearch.DataSource = _BLTablesSearch.getSearchFields(TableName);
            DDLSearch.DataTextField = "FieldText";
            DDLSearch.DataValueField = "FieldValue";
            DDLSearch.DataBind();
        }
    }
    protected void getSearchResults(object sender, EventArgs e)
    {
        string FieldName=DDLSearch.SelectedValue;
        string SearchText=txtSearch.Text.Replace(" ","");
        // TODO: filter the AllRecords Table according to what ever you want
        DataTable filteredRecords = YourFilteringFunction(FieldName,SearchText);
        if(OnSearchComplete != null)
            OnSearchComplete(filteredRecords);
    }
