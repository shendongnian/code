    private IDetailViewFactory _detailViewFactory;
        public UserDetailPresenter(IDetailViewFactory detailViewFactory)
        {
            _detailViewFactory = detailViewFactory;
        }
    public void Show(IUser user ) 
            { 
                _view = _detailViewFactory.Resolve();//Some method to get a new view
                InitializeView(user);
                _view.Show();
            }
