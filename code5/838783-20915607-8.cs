    public class UserDetailPresenter : IPresenter<IUserDetailView> 
    {
        private IDetailView _view;
        public UserDetailPresenter(IDetailView detailView, IUser user)
        {
            _view = detailView;
             LoadUser(user)
            _view.Show();
        }
    }
