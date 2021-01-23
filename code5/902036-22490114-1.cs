        private void stopsLLS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (stopsLLS.SelectedItem == null)
                return;
            // Save Selected Item
            PhoneApplicationService.Current.State["SelectedStop"] = stopsLLS.SelectedItem as Stop;
            // Navigate to the new page
            NavigationService.Navigate(new Uri("/Views/StopSchedulePage.xaml", UriKind.Relative));
            // Reset selected item to null (no selection)
            reportsLLS.SelectedItem = null;
        }
