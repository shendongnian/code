        private void GoTo()
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.NavigateTo<Page2>(null);
        }
        public ICommand GoToCommand
        {
            get
            {
                return new RelayCommand(GoTo);
            }
        }
