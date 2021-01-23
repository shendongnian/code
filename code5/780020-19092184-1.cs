    class SomeViewModel
    {
        private IViewService mViewService;
        public SomeViewMode(IViewService _viewService)
        {
            mViewService = _viewService;
            //Whenever you need to show your View call:
            mViewService.ShowViewAndWaitForClosing(doSomething);
        }
        private void doSomething() 
        {
            //...
        }
    }
