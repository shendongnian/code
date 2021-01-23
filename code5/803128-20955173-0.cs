    private void layoutModeButton_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton layoutModeButton = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (MainLongListSelector.LayoutMode == LongListSelectorLayoutMode.Grid)
            {
                MainLongListSelector.LayoutMode = LongListSelectorLayoutMode.List;
                MainLongListSelector.ItemTemplate = this.Resources["ListListLayout"] as DataTemplate;
                layoutModeButton.IconUri = _gridButtonUri;
                layoutModeButton.Text = "grid";
            }
            else
            {
                MainLongListSelector.LayoutMode = LongListSelectorLayoutMode.Grid;
                MainLongListSelector.ItemTemplate = this.Resources["GridListLayout"] as DataTemplate;
                layoutModeButton.IconUri = _listButtonUri;
                layoutModeButton.Text = "list";
            }
        }
