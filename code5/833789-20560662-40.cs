    public sealed class FatherViewModel : ViewModelBase
    {
        private SonViewModel _sonViewModel;
        public SonViewModel SonViewModel
        {
            get { return _sonViewModel; }
            set
            {
                if (SonViewModel != null)
                    SonViewModel.Event -= OnUserControlViewModelEvent;
                Set(() => SonViewModel, ref _sonViewModel, value);
                if (SonViewModel != null)
                    SonViewModel.Event += OnUserControlViewModelEvent;
            }
        }
        private void OnUserControlViewModelEvent(object sender, EventArgs args)
        {
            // violation of MVVM for the sake of simplicity
            MessageBox.Show("I got here!");
        }
    }
