        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Add all names to a list
            List<string> clientsSelected = new List<string>();
            foreach (PrairieDeskClients client in prairieDeskClientDataGridConfigurationStep1.ItemsSource)
            {
                if (client.IsChecked == true)
                {
                    clientsSelected.Add(client.Hostname);
                }
            }
            //Build string of hostnames that are changing
            applyChangesToTheseClients.Text = string.Join(", ", clientsSelected);
        }
