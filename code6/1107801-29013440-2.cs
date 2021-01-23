    if (!IsPostBack)
    {
         myList = new List<Foo>();
         ViewState["myList"] = myList;
    }
    else
    {
         myList = (List<Foo>)ViewState["myList"];
    }
    protected void btnTeste_Click(object sender, EventArgs e)
    {
        myList.Add(new Foo { Id = 0, Name = "Nobody" }); //NullReferenceException - myList is null here!
        ViewState["myList"] = myList;
    }
