    private void deleteEntryBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            people.RemoveAt(listBoxNames.SelectedIndex);
            listBoxNames.RemoveAt(listBoxNames.SelectedIndex);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
