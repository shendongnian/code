    public class CurrentViewModelPresenter : MvxTouchViewPresenter, ICurrentViewModelPresenter
    {
        public CurrentViewModelPresenter(UIApplicationDelegate del, UIWindow win)
            : base(del, win)
        {
        }
        public IMvxViewModel CurrentViewModel
        { 
            get
            {
                var viewController = MasterNavigationController.TopViewController;
                if (viewController == null) return null;
                var touchView = viewController as IMvxTouchView;
                if (touchView == null) return null;
                return touchView.ReflectionGetViewModel();
            }
        }
    }
