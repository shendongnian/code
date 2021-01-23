    public class StrechItemsListView : ListView
    {
        public StrechItemsListView()
        {
            this.SizeChanged += StrechItemsListView_SizeChanged;
        }
        private void StrechItemsListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ItemsPanelRoot != null)
            {
                ItemsPanelRoot.Width = e.NewSize.Width;
            }
        }
    }
