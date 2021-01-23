    private void View_Loaded(object sender, RoutedEventArgs e)
    {
        var listView = (sender as ListView);
        var gridView = (listView.View as GridView);
        // Standard safety check.
        if (listView == null || gridView == null)
        {
            return;
        }
        // Initialize a new typeface based on the currently used font.
        var typeFace = new Typeface(listView.FontFamily, listView.FontStyle, 
                                    listView.FontWeight, listView.FontStretch);
        // This variable will hold the longest string from the source list.
        var longestString = dataList.OrderByDescending(s => s.Length).First();
        // Initialize a new FormattedText instance based on our longest string.
        var text = new System.Windows.Media.FormattedText(longestString, 
                           System.Globalization.CultureInfo.CurrentCulture,
                           System.Windows.FlowDirection.LeftToRight, typeFace,  
                           listView.FontSize, listView.Foreground);
        // Assign the width of the FormattedText to the column width.
        gridView.Columns[0].Width = text.Width;
    }
