    DataClassesDataContext DS = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        var _news = DS.News.OrderBy(n => n.ID).Take(5).ToList();
    }
