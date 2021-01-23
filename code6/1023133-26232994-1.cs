        private void DataGridHeader_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var header = e.OriginalSource as ContentControl;
                if (header != null)
                {
                    DragDrop.DoDragDrop(header, new DataObject(typeof(string), header.Content.ToString()), DragDropEffects.Move);
                    e.Handled = true;
                }
            }
        }
        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                var columnName = (string)e.Data.GetData(typeof(string));
                MyGroupDescriptionsList.Items.Add(columnName);
                var sourceView = CollectionViewSource.GetDefaultView(MyDataGrid.ItemsSource);
                sourceView.GroupDescriptions.Add(new PropertyGroupDescription(columnName));
                sourceView.Refresh();
                
                e.Handled = true;
            }
        }
