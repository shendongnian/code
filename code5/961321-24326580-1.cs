        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // This will be called whenever the view is navigated to.
            // Extract the querystring value(s).
            var employeeId = navigationContext.Parameters["empid"];
            .. etc..
        }
