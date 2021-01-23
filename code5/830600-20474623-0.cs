        private UCDummy1 ucDummy1;
        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            var item = new TreeViewItem();
            item.Header = "Options";
            item.ItemsSource = new string[] {"Dummy1", "Dummy2", "Dummy3"};
            var tree = sender as TreeView;
            tree.Items.Add(item);
            PopulateConfigUserControls();
        }
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var tree = sender as TreeView;
            if (tree.SelectedItem is string)
            {
                string selectedUC = tree.SelectedItem.ToString();
                PanelOption.Children.Clear();
                if (selectedUC == "Dummy1")
                {
                    PanelOption.Children.Add(ucDummy1);
                }
            }
        }
        private void PopulateConfigUserControls()
        {
            ucDummy1 = new UCDummy1();
            ucDummy1.TextBoxVoornaam.Text = Settings.Default.Voornaam;
            ucDummy1.TextBoxAchternaam.Text = Settings.Default.Achternaam;
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Voornaam = ucDummy1.TextBoxVoornaam.Text;
            Settings.Default.Achternaam = ucDummy1.TextBoxAchternaam.Text;
            Settings.Default.Save();
        }
