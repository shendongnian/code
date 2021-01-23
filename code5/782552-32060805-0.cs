            int i = 1;
            foreach (ListViewItem item in listView.Items)
            {
                if (i % 2 == 0)
                {
                    item.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                    item.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                }
                else
                {
                    item.Background = new SolidColorBrush(Windows.UI.Colors.White);
                    item.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                }
                i++;
            }
