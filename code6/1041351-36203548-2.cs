    [ImplementPropertyChanged]
    public class NavigatorViewModel
    {
        public NavigatableViewModel CurrentViewModel { get; set; }
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
        public ICommand BackCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    // Set current control to previous control
                    CurrentViewModel = CurrentViewModel.PreviousViewModel;
                }, () => CurrentViewModel != null && CurrentViewModel.PreviousViewModel != null);
            }
        }
        public ICommand ForwardCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    // Set current control to next control
                    CurrentViewModel = CurrentViewModel.NextViewModel;
                }, () => CurrentViewModel != null && CurrentViewModel.NextViewModel != null);
            }
        }
    }
