    public class HomePageRotatorItem : DataItemBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="spListItem">The SPListItem to create the DataItemBase from</param>
        public HomePageRotatorItem(SPListItem spListItem) : base(spListItem)
        {
        }
        public string HeroImageUrl
        {
            get { return SpListItem["HeroImage"].ToString(); }
        }
        public string HeroImageUrl2
        {
            get { return SpListItem["HeroImageCallOut"].ToString(); }
        }
        public string ExplanatoryText
        {
            get { return SpListItem["ExplanatoryText"].ToString(); }
        }
        public string AttentionExplanatoryText2
        {
            get { return SpListItem["ExplanatoryText"].ToString(); }
        }
        public string ExplanatoryText2
        {
            get { return SpListItem["ExplanatoryText"].ToString(); }
        }
        public string HomeSliderImageUrl
        {
            get { return SpListItem["ExpandedSliderImage"].ToString(); }
        }
        public string GreenFlyoutText
        {
            get { return SpListItem["GreenFlyoutText"].ToString(); }
        }
    }
