        private void OnNewTabSelected(object sender, RoutedEventArgs e)
        {
            if (e.Source is TabItem && this.IsLoaded)
            {
                TabItem MyTab = (TabItem)sender;
                TabControl MyControl = (TabControl)MyTab.Parent;
                if (MyControl.SelectedIndex == 0)
                {
                    MessageBox.Show("Beep" + MyControl.SelectedIndex);
                }
                else if (MyControl.SelectedIndex == 1)
                {
                    MessageBox.Show("Beep" + MyControl.SelectedIndex);
                }
                else if (MyControl.SelectedIndex == 2)
                {
                    MessageBox.Show("Beep" + MyControl.SelectedIndex);
                }
            }
        }
