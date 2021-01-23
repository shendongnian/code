        void MenuItem_Click(object sender, RoutedEventArgs e) {
            var lvi = new ListViewItem();
            lvi.Content = String.Format("New thing {0}", DateTime.Now);
            MyListView.Items.Add(lvi);
            }
