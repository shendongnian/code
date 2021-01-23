    class FirstOne: ViewModel
    {
        private readonly INavigation _navigation;
        public FirstOne(INavigation navigation) { _navigation = navigation; }
        public void ButtonClicked()
        {
            _navigation.Show(new SecondOne());
        }
    }
