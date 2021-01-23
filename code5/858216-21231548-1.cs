        private void OnClick(object sender, RoutedEventArgs e)
        {
            TextBox tbx = null;
            // grid is a panel, panels have children
            var parent = VisualTreeHelper.GetParent((DependencyObject)sender) as Panel;
            foreach(var child in parent.Children)
            {
                if (child is TextBox)
                {
                    tbx = (TextBox)child;
                    break;
                }
            }
            // you should check if tbx != null
            tbx.Text = "Hello";
        }
