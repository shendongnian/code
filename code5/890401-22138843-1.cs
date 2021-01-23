     private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
            {
                TabControl control = sender as TabControl;
                if (control != null && control.SelectedItem is Tab)
                {
                    if ((control.SelectedItem as Tab).Header == " ")
                    {
                        (control.SelectedItem as Tab).Header = "New Tab";
                        (control.DataContext as TabViewModel).Items.Add(new Tab() { Header = " ", Content = "" });
                        control.UpdateLayout();
                    }
                }
            }
