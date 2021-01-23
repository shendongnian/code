    public string ArtType { get; set; }
    
    public string GetArtType()
    {
        return ArtType;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //datasource is the name of your datasource 
            ArtType = datasource.First().ArtType_ID.ToString();
            DL_ElarabyNews.DataSource = datasource;
            DL_ElarabyNews.DataBind();
        }
    }
