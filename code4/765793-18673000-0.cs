    private void categoriesListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (categoriesListPicker.SelectedItem != null)
        {
                    string selectedItem = categoriesListPicker.SelectedItem as string;
                    MessageBox.Show(selectedItem);
        }
    }
