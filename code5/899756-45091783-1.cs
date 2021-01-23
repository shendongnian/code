    void listView_Loaded(object sender, RoutedEventArgs e)
    {
        var listView = sender as System.Windows.Controls.ListView;
        if(listView == null) return;
        var gridView = listView.View as GridView;
        if(gridView == null) return;
        // this assumes the items are coming from data binding.
        // generating an iteration of strings from your actual data source
        // is left as an exercise to the reader
        var dataList = listView.Items.SourceCollection as List<string>;
        if(dataList == null) return;
        var typeFace = new Typeface(listView.FontFamily, listView.FontStyle,
                                        listView.FontWeight, listView.FontStretch);
        var text = getLongestFormattedString(dataList, typeFace, listView.FontSize);
        gridView.Columns[0].Width = text.WidthIncludingTrailingWhitespace;
    }
