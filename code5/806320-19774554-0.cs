    if (!Page.IsPostBack)
    {
        MyDdl.DataSource = MyObjectList; //Containing A, B, C
        MyDdl.DataBind();
        MyDdl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    }
