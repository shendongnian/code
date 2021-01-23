    public class MyBlockController : BlockController<MyBlock>
    {
        private readonly PageRouteHelper _pageRouteHelper;
        public override ActionResult Index(MyBlock currentContent)
        {
            Guid hostingPageId = _pageRouteHelper.Page.PageGuid;
        }
    }
