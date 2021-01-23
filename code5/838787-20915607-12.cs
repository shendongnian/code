    public class UserDetailPresenter : IPresenter<IUserDetailView> 
    {
        private IDetailView _view;
        public UserDetailPresenter(IDetailView detailView, IUser user)
        {
            _view = detailView;
             LoadUser(user);
             _view.SomeProperty = _userData;//to populate view with data
            _view.Show(); // tells the view to show data
        }
    }
