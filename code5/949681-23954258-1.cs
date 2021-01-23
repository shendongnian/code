    var list = new List<string>();
            
    for (int i = 0; i < 10; i++)
    {
        list.Add(string.Empty);
    }
    gv_Others.DataSource = list;
    gv_Others.DataBind();
