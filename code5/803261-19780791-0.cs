    protected void Page_Load(object sender, EventArgs e)
    {
        var cm = new ContentManager();
        var criteria = new ContentCriteria();
        criteria.AddFilter(ContentProperty.Type, CriteriaFilterOperator.EqualTo, EkEnumeration.CMSContentType.Content);
        cvPrimary.Model.ContentList = cm.GetList(criteria);
    }
