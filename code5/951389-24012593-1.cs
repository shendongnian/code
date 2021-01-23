        private void SelectAll_OnClick(object sender, RoutedEventArgs e)
        {
            bool? isChecked = SelectAllCheckBox.IsChecked;
            if (isChecked.HasValue)
            {
                foreach (BaseDataItem objItem in BaseReleaseList)
                {
                    objItem.Select = isChecked;
                }
                BaseReleaseDataGridView.Items.Refresh();
            }
        }
