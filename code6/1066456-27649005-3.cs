            private void handleWindowkeyUp(object sender, KeyEventArgs e)
            {
                lblMode.Visibility = System.Windows.Visibility.Visible;
                if (e.Key == Key.Space)
                {
                    lblMode.Content = (lblMode.Content.ToString() == "IN") ? "OUT" : "IN";                           return;
                }
            }
            private void btnAdmin_Click(object sender, RoutedEventArgs e)
            {
                DisplayAdminWindow();
            }
