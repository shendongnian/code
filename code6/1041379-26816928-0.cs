    protected void Page_Load(object sender, EventArgs e)
    {
    
    if(!Page.IsPostBack)
    {
       AddListItems();
    }
    }
    
    Protected Void AddListItems()
    {
     // Populate parent
        for(...) LBParent.Items.Add(...);
        for(...) SecondList.Items.Add(...);
        for(...) ThirdList.Items.Add(...);
    }
