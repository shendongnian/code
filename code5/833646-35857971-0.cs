    protected void FundList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        uxTopPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        uxBottomPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        BindListView();    //Function where datas are binded to listview
    }
