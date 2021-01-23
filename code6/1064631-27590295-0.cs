    public DataTable AllRecords { get { return Session["AllRecords"]; } set { Session["AllRecords"] = value;} }
    public string TableName;
    BLTablesSearch _BLTablesSearch = new BLTablesSearch();
    protected void getSearchResults(object sender, EventArgs e)
    {
        string FieldName=DDLSearch.SelectedValue;
        string SearchText=txtSearch.Text.Replace(" ","");
        // TODO: filter the AllRecords Table according to what ever you want
        DataTable filteredRecords = YourFilteringFunction(FieldName,SearchText);
        if(OnSearchComplete != null)
            OnSearchComplete(filteredRecords);
    }
