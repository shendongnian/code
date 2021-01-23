    public void test1_OnLoad(object sender, EventArgs e)
    {     
        var list = // Get your data from the database.  Return as an IList<T> or something   
                   //similar.
        test1.DataSource = list;
        test1.ItemPlaceholderID = "test1PlaceHolder";
        test1.DataBind();
    }
