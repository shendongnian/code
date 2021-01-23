    protected void Page_Load(object sender, EventArgs e)
    {
        using (Property_dbDataContext context = new Property_dbDataContext())
        {
            var strURL = context.retrieveImage()
                    .Select(s => s.image_url)
                    .ToList();
            rptImageList.DataSource = strURL;
            rptImageList.DataBind();            
        }
    }
