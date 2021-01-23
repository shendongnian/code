    private void acBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (e.AddedItems.Count > 0)
                {
                    ItemViewModel firstItem = e.AddedItems[0] as ItemViewModel;
                    if (firstItem != null)
                    {
                        int fileId = firstItem.HymnId;
                        fileId = fileId - 1;
                        NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + fileId, UriKind.Relative));
                    }
                }
            }
