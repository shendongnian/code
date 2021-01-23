    protected void Page_Load(object sender, EventArgs e)
    {
        rptContent.DataSource = Results();
        rptContent.DataBind();
    }
    public List<Sample> Results()
    {    
            List<Sample> List = new List<Sample>();    
            myList.Add(new Sample { Title = "Title   
    1", Link = "/item.aspx?id=1", Summary = "summary     
    for Item 1" });
    
            return List;
    }
