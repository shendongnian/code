private void GridView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (sender is GridView)
            {
                (sender as GridView).ReorderMode = ListViewReorderMode.Enabled;
            }
        }
