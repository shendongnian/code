    [ImplementPropertyChanged]
    public class MainNavigatableViewModel : NavigatableViewModel
    {
        public ICommand LoadProfileCommand { get; private set; }
        public ICommand OpenPostCommand { get; private set; }
        public MainNavigatableViewModel ()
        {
            LoadProfileCommand = new RelayCommand(() => Navigator.Navigate(new ProfileNavigatableViewModel()));
            OpenPostCommand = new RelayCommand(() => Navigator.Navigate(new PostEditViewModel { Post = SelectedPost }), () => SelectedPost != null);
        }
    }
