    public class UserDetailPresenter : IPresenter<IUserDetailView> 
    {
        private IDetailView _view;
        public UserDetailPresenter()
        {
            
        }
        public void Show(IUser user, IDetailView detailView) 
            { 
                _view = detailView;
                InitializeView(user);
                _view.Show();
            }
    }
