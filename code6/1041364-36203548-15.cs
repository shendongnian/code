    [ImplementPropertyChanged]
    public class NavigatorViewModel
    {
        public NavigatableViewModel CurrentViewModel { get; set; }
        public ICommand BackCommand { get; private set; }
        public ICommand ForwardCommand { get; private set; }
        public NavigatorViewModel()
        {
            BackCommand = new RelayCommand(() =>
            {
                // Set current control to previous control
                CurrentViewModel = CurrentViewModel.PreviousViewModel;
            }, () => CurrentViewModel != null && CurrentViewModel.PreviousViewModel != null);
            ForwardCommand = new RelayCommand(() =>
            {
                // Set current control to next control
                CurrentViewModel = CurrentViewModel.NextViewModel;
            }, () => CurrentViewModel != null && CurrentViewModel.NextViewModel != null);
        }
        
        public void Navigate(NavigatableViewModel newViewModel)
        {
            if (newViewModel.Navigator != null && newViewModel.Navigator != this)
                throw new Exception("Viewmodel can't be added to two different navigators");
            newViewModel.Navigator = this;
            if (CurrentViewModel != null)
            {
                CurrentViewModel.NextViewModel = newViewModel;
            }
            newViewModel.PreviousViewModel = CurrentViewModel;
            CurrentViewModel = newViewModel;
        }
    }
