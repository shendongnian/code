    public abstract class MyPageBase<T> : WebViewPage<T>
    {
        protected override void InitializePage()
        {
            ViewBag.Menu = new Menu();
            base.InitializePage();
        }
    }
