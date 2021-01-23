         var grid = new StackPanel();
         grid.Children.Add(myList);
         scroll.Content = grid;
         var dialog = new ContentDialog { Title = "Title", Content = scroll };
         var s = dialog.ShowAsync();
