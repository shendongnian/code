    BLPerson BLPerson = new BLPerson();
    BLREOptions BLREOptions = new BLREOptions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable allPersons = BLPerson.getAllPersons();
            QuickSearchControl.AllRecords = allPersons;
            PersonListGridView.DataSource = allPersons;
            PersonListGridView.DataBind();
            QuickSearchControl.TableName = "Person";
        }
        QuickSearchControl.OnSearchComplete += new UserControls.QuickSearchControl.SearchComplete(HandleOnSearchComplete);
    }
    public void HandleOnSearchComplete(DataTable _searchResult)
    {
            PersonListGridView.DataSource = _searchResult;
            PersonListGridView.DataBind();
    }
