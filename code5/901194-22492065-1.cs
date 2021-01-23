    public class Setup : MvxTouchSetup
    {
        private readonly MvxApplicationDelegate _del;
        private readonly UIWindow _win;
        public Setup(MvxApplicationDelegate del, UIWindow win)
            : base(del, win)
        {
            _del = del;
            _win = win;
        }
        ...
        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            var presenter = new CurrentViewModelPresenter(_del, _win);
            Mvx.RegisterSingleton<ICurrentViewModelPresenter>(presenter);
            return presenter;
        }
    }
