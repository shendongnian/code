    protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = null;
            if (SPContext.Current != null)
            {
                site = SPContext.Current.Site;
            }
            SPList list = site.RootWeb.Lists["HomePageHero"];
            SPListItemCollection myItems = list.Items;
            var rotatorItems = myItems.Cast<SPListItem>().Select(x => new HomePageRotatorItem(x));
            //IEnumerable eList = myItems.Fields as IEnumerable;
            //List<ExpandedHomeSlider> expandedSliderList = new List<ExpandedHomeSlider>();
            //var expandedSliderList = new List<string>();
            
            //foreach (SPListItem item in myItems)
            //{
            //    var newExpandedSlider = new ExpandedHomeSlider() { ExplanatoryText = item["Explanatory Text"]}
            //    ExpandedHomeSlider ExplanatoryText = item["Explanatory Text"].ToString();
            //    expandedSliderList.Add(ExplanatoryText);       
            //}
            HomePageHeroRpt.DataSource = rotatorItems;
            HomePageHeroRpt.DataBind();
