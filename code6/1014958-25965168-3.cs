    WindowsColorPallete.DataContext = null;
    WindowsColorPallete.DataContext = viewModel.PaletteEntries;
    private void WindowsColorPallete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!WindowsColorPallete.IsReadOnly)
                return;
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                DataGridRow row = dep as DataGridRow;
                var ple = (ColorPickerViewModel.PaletteEntry)row.Item;
                currentPaletteEntry = ple;
 
                // HERE AS AN EXAMPLE IS WHERE I WOULD INSTANTIATE A NEW LABEL AND SET THE PROPERTIES
                // FROM THE ObservableCollection 
                // EG
                var l = new Label();
                l.Content = ple.Title;
                // ETC :) 
                if (ple.Title != "")
                    TitleValue.Text = ple.Title;
                if (ple.Tags != "")
                    TagsValue.Text = ple.Tags;
            }
        }
