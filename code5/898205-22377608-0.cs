        private void OnNavigationButtonExecution()
        {
            Properties.Settings.Default.IsNavigationAreaCollapsed = !Properties.Settings.Default.IsNavigationAreaCollapsed
            CollapseNavigationArea(Properties.Settings.Default.IsNavigationAreaCollapsed); // this will collapse or not the navoigation area
            Properties.Settings.Default.Save(); //save settings, so that it will be stored when app shutsdown
        }
